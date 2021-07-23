using System;

namespace MTG.Backend
{

    public partial class PlayerLife
    {
        private int m_value;

        public int Value
        {
            get => m_value;
            set
            {
                int valueBefore = m_value;
                m_value = value;

                if (m_value > valueBefore)
                    OnLifeDecreased?.Invoke(valueBefore - m_value);
                else if (m_value < valueBefore)
                    OnLifeIncreased?.Invoke(valueBefore - m_value);

                if (valueBefore > 0 && m_value <= 0)
                    OnReachedZero?.Invoke();
            }
        }

        public PlayerLife(int lifeValue)
        {
            m_value = lifeValue;

            OnLifeIncreased = null;
            OnLifeDecreased = null;
            OnReachedZero = null;
        }

        public PlayerLife(uint lifeValue)
        {
            m_value = (int) lifeValue;

            OnLifeIncreased = null;
            OnLifeDecreased = null;
            OnReachedZero = null;
        }

        public static implicit operator PlayerLife(int lifeValue) => new PlayerLife(lifeValue);
        public static implicit operator int(PlayerLife life) => life.Value;

        public bool IsAlive => Value > 0;

        public Action<int> OnLifeIncreased;
        public Action<int> OnLifeDecreased;
        public Action OnReachedZero;
    }

    public partial class PlayerLife : ICloneable
    {

        public object Clone()
        {
            return new PlayerLife(m_value)
            {
                OnLifeIncreased = OnLifeIncreased,
                OnLifeDecreased = OnLifeDecreased,
                OnReachedZero = OnReachedZero
            };
        }

    }

}
