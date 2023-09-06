namespace HitmasterClone
{
    public class EnemyHealthController
    {
        public EnemyHealthController(EnemyHealthUI healthUI, EnemyData data, Enemy enemy)
        {
            healthUI.Refresh(data.NormalizedHealth);

            enemy.OnTakeDamage += (_) => healthUI.Refresh(data.NormalizedHealth);
            data.OnDeath += () => healthUI.Enable(false);
        }
    }
}