using System;
using System.Collections.Generic;

public interface IExecutable
{
    void Execute();
}

public interface IReversible
{
    void Undo();
}

public interface INotifiable
{
    void SendNotification();
}

public interface ITrackable
{
    void Track();
    string GetStats();
}

public interface IModeratable
{
    bool IsApproved { get; set; }
    void Moderate(bool approve);
}

public abstract class SocialAction : IExecutable, ITrackable
{
    protected string User { get; set; }
    protected DateTime Timestamp { get; set; }
    protected static int TotalActionsCount { get; set; }

    public SocialAction(string user)
    {
        User = user;
        Timestamp = DateTime.Now;
    }

    public abstract void Execute();

    public virtual void Track()
    {
        TotalActionsCount++;
        Console.WriteLine($"[Статистика] Действие от {User} зарегистрировано");
    }

    public string GetStats()
    {
        return $"Всего действий: {TotalActionsCount}";
    }

    public override string ToString()
    {
        return $"{GetType().Name} от {User} в {Timestamp}";
    }
}

public class Like : SocialAction, IReversible, INotifiable
{
    private string TargetPost { get; set; }
    private bool isActive;

    public Like(string user, string targetPost) : base(user)
    {
        TargetPost = targetPost;
        isActive = false;
    }

    public override void Execute()
    {
        isActive = true;
        Console.WriteLine($"❤️ {User} лайкнул пост '{TargetPost}'");
        Track();
        SendNotification();
    }

    public void Undo()
    {
        if (isActive)
        {
            isActive = false;
            Console.WriteLine($"💔 {User} убрал лайк с поста '{TargetPost}'");
        }
    }

    public void SendNotification()
    {
        Console.WriteLine($"[Уведомление] Автору поста: Ваш пост получил лайк от {User}");
    }
}

public class Comment : SocialAction, IReversible, INotifiable, IModeratable
{
    private string TargetPost { get; set; }
    private string CommentText { get; set; }
    private bool isActive;
    public bool IsApproved { get; set; }

    public Comment(string user, string targetPost, string text) : base(user)
    {
        TargetPost = targetPost;
        CommentText = text;
        isActive = false;
        IsApproved = false;
    }

    public override void Execute()
    {
        if (IsApproved)
        {
            isActive = true;
            Console.WriteLine($"💬 {User} прокомментировал пост '{TargetPost}': \"{CommentText}\"");
            Track();
            SendNotification();
        }
        else
        {
            Console.WriteLine($"⏳ Комментарий от {User} ожидает модерации");
        }
    }

    public void Undo()
    {
        if (isActive)
        {
            isActive = false;
            Console.WriteLine($"🗑️ Комментарий от {User} удален");
        }
    }

    public void SendNotification()
    {
        Console.WriteLine($"[Уведомление] Новый комментарий к посту от {User}");
    }

    public void Moderate(bool approve)
    {
        IsApproved = approve;
        Console.WriteLine(approve ?
            $"✅ Комментарий от {User} одобрен" :
            $"❌ Комментарий от {User} отклонен");
    }
}

public class Repost : SocialAction, INotifiable, ITrackable
{
    private string OriginalPost { get; set; }
    private string RepostText { get; set; }

    public Repost(string user, string originalPost, string repostText = "") : base(user)
    {
        OriginalPost = originalPost;
        RepostText = repostText;
    }

    public override void Execute()
    {
        Console.WriteLine($"🔄 {User} сделал репост:");
        Console.WriteLine($"   Оригинал: '{OriginalPost}'");
        if (!string.IsNullOrEmpty(RepostText))
        {
            Console.WriteLine($"   Комментарий: '{RepostText}'");
        }
        Track();
        SendNotification();
    }

    public new void Track()
    {
        base.Track();
        Console.WriteLine($"[Статистика] Репост от {User} увеличил охват поста");
    }

    public void SendNotification()
    {
        Console.WriteLine($"[Уведомление] Ваш пост был репостнут {User}");
    }
}

public class Subscription : SocialAction, IReversible, INotifiable, IModeratable
{
    private string TargetUser { get; set; }
    private bool isSubscribed;
    public bool IsApproved { get; set; }

    public Subscription(string user, string targetUser) : base(user)
    {
        TargetUser = targetUser;
        isSubscribed = false;
        IsApproved = true;
    }

    public override void Execute()
    {
        if (IsApproved)
        {
            isSubscribed = true;
            Console.WriteLine($"👤 {User} подписался на {TargetUser}");
            Track();
            SendNotification();
        }
        else
        {
            Console.WriteLine($"⏳ Подписка {User} на {TargetUser} ожидает подтверждения");
        }
    }

    public void Undo()
    {
        if (isSubscribed)
        {
            isSubscribed = false;
            Console.WriteLine($"🚫 {User} отписался от {TargetUser}");
        }
    }

    public void SendNotification()
    {
        Console.WriteLine($"[Уведомление] У вас новый подписчик: {User}");
    }

    public void Moderate(bool approve)
    {
        IsApproved = approve;
        Console.WriteLine(approve ?
            $"✅ Подписка {User} на {TargetUser} одобрена" :
            $"❌ Подписка {User} на {TargetUser} отклонена");
    }
}

public class Complaint : SocialAction, IModeratable, ITrackable
{
    private string TargetContent { get; set; }
    private string Reason { get; set; }
    public bool IsApproved { get; set; }

    public Complaint(string user, string targetContent, string reason) : base(user)
    {
        TargetContent = targetContent;
        Reason = reason;
        IsApproved = false;
    }

    public override void Execute()
    {
        Console.WriteLine($"⚠️ Жалоба от {User} на '{TargetContent}'");
        Console.WriteLine($"   Причина: {Reason}");
        Track();
    }

    public new void Track()
    {
        base.Track();
        Console.WriteLine($"[Статистика] Зарегистрирована жалоба от {User}");
    }

    public void Moderate(bool approve)
    {
        IsApproved = approve;
        if (approve)
        {
            Console.WriteLine($"✅ Жалоба на '{TargetContent}' принята, контент проверяется");
        }
        else
        {
            Console.WriteLine($"❌ Жалоба на '{TargetContent}' отклонена");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== СИСТЕМА СОЦИАЛЬНЫХ ДЕЙСТВИЙ ===\n");

        var actions = new List<IExecutable>
        {
            new Like("Alice", "Фото заката"),
            new Comment("Bob", "Фото заката", "Красиво!"),
            new Repost("Charlie", "Фото заката", "Согласен, отличное фото"),
            new Subscription("David", "Alice"),
            new Complaint("Eve", "Спам-пост", "Реклама казино")
        };

        Console.WriteLine("--- Выполнение действий ---");
        foreach (var action in actions)
        {
            action.Execute();
            Console.WriteLine();
        }

        Console.WriteLine("--- Модерация контента ---");
        var moderatableActions = new List<IModeratable>();

        foreach (var action in actions)
        {
            if (action is IModeratable modAction)
            {
                moderatableActions.Add(modAction);
            }
        }

        if (moderatableActions.Count > 0)
        {
            var comment = (Comment)moderatableActions[0];
            comment.Moderate(true);
            comment.Execute();
            Console.WriteLine();
        }

        Console.WriteLine("--- Отмена действий ---");
        foreach (var action in actions)
        {
            if (action is IReversible reversible)
            {
                reversible.Undo();
                Console.WriteLine();
            }
        }

        Console.WriteLine("--- Статистика ---");
        if (actions.Count > 0)
        {
            var trackable = (ITrackable)actions[0];
            Console.WriteLine(trackable.GetStats());
        }

        Console.WriteLine("\n--- История действий ---");
        foreach (SocialAction action in actions)
        {
            Console.WriteLine(action);
        }
    }
}