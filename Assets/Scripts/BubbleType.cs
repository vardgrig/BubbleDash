public enum BubbleType
{
    Killer, // pops instantly (enemy) 
    AddTimer, // adds seconds +
    ReduceTimer, // reduces timer (enemy) +
    ExtraDash, // adds extra dash +
    Burst, // kills nearby "enemy" bubbles (optional)
    DashSlowdown, // decreases dash's speed and range (enemy) (optional)
    Multiplier, // x2 coins (optional)
    FreezeTimer, // freezes the timer +
    Invert, // inverts character's controls (mouse) (enemy) (optional)
    Mirror, // creates fake bubbles (enemy) (trigger an event) (optionalx2)
    Bomb, // pops the bubble after certain time +
}