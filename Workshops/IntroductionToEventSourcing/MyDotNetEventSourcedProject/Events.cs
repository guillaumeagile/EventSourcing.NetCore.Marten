namespace MyDotNetEventSourcedProject;

public enum BobyPart
{
    Head
}

public record PlayerDiedEvent(int PlayerId);

public record PlayerAttackedByZombieEvent(int PlayerId, int ZombieId, BobyPart Target);
