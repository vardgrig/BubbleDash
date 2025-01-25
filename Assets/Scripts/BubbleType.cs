public enum BubbleType
{
    Killer, // +++++++++ pops instantly (enemy) 
    AddTimer, // +++++++++ adds seconds 
    ReduceTimer, // ++++++++++ reduces timer (enemy) 
    ExtraDash, // ++++++++++ adds extra dash 
    Burst, // +++++++++++ kills nearby "enemy" bubbles 
    DashSlowdown, // +++++++++++ decreases dash's speed and range (enemy) 
    FreezeTimer, // +++++++++++ freezes the timer 
    Invert, // +++++++++ inverts character's controls (enemy) 
    Mirror, // TODO: creates fake bubbles (enemy) (trigger an event) (optionalx2)
    Bomb, // ++++++++++ pops the bubble after certain time (enemy)
}