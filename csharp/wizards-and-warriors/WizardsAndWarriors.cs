using System;

abstract class Character(string characterType)
{
    protected string _characterType = characterType;

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() => $"Character is a {_characterType}";
}

class Warrior() : Character("Warrior")
{
    public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;
}

class Wizard() : Character("Wizard")
{
    protected bool _spellPrepared = false;

    public override int DamagePoints(Character target) => _spellPrepared ? 12 : 3;

    public void PrepareSpell() => _spellPrepared = true;

    public override bool Vulnerable() => !_spellPrepared;
}
