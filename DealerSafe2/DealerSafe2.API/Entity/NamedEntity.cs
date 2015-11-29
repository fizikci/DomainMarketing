using System;

namespace DealerSafe2.API.Entity
{
    public class NamedEntity : BaseEntity
    {
        public string Name { get; set; }
        public int OrderNo { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public virtual void MoveUp()
        {
            var upEntity = (NamedEntity)Provider.Database.Read(this.GetType(), "OrderNo={0}", OrderNo - 1);
            if (upEntity == null)
                return;

            upEntity.OrderNo++;
            upEntity.Save();

            this.OrderNo--;
            this.Save();
        }
        public virtual void MoveDown()
        {
            var downEntity = (NamedEntity)Provider.Database.Read(this.GetType(), "OrderNo={0}", OrderNo + 1);
            if (downEntity == null)
                return;

            downEntity.OrderNo--;
            downEntity.Save();

            this.OrderNo++;
            this.Save();
        }
    }
}