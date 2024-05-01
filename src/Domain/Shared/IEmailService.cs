namespace Domain.Shared;

public interface IEmailService
{
    string SendEmailAsync(Domain.Game.Game game, string text);
}