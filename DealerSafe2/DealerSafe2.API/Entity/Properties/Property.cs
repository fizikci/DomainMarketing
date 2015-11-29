using System;
using Cinar.Database;

namespace DealerSafe2.API.Entity.Properties
{
    public class Property : NamedEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 12)]
        public string PropertySetId { get; set; }

        public string GroupName { get; set; }
        public string PropType { get; set; }
        public string Options { get; set; }
        public string DefaultValue { get; set; }
        public bool Public { get; set; }

        public PropertySet PropertySet() { return Provider.ReadEntityWithRequestCache<PropertySet>(PropertySetId); }

        public override void BeforeSave(bool isUpdate)
        {
            base.BeforeSave(isUpdate);

            if(!isUpdate && OrderNo==0)
                this.OrderNo = Provider.Database.GetInt("select max(OrderNo)+1 from Property where PropertySetId = {0}", PropertySetId);
        }

        public override void MoveUp()
        {
            var upEntity = (Property)Provider.Database.Read(this.GetType(), "PropertySetId = {0} AND OrderNo={1}", PropertySetId, OrderNo - 1);
            if (upEntity == null)
                return;

            if (upEntity.GroupName != this.GroupName)
            {
                Provider.Database.ExecuteNonQuery("update roperty set OrderNo = OrderNo + {2} where PropertySetId = {0} AND GroupName={1}", PropertySetId, upEntity.GroupName, Provider.Database.GetInt("select count(*) from Property where PropertySetId = {0} AND GroupName={1}", PropertySetId, this.GroupName));
                Provider.Database.ExecuteNonQuery("update roperty set OrderNo = OrderNo - {2} where PropertySetId = {0} AND GroupName={1}", PropertySetId, this.GroupName, Provider.Database.GetInt("select count(*) from Property where PropertySetId = {0} AND GroupName={1}", PropertySetId, upEntity.GroupName));
            }
            else
            {
                upEntity.OrderNo++;
                upEntity.Save();

                this.OrderNo--;
                this.Save();
            }
        }

        public override void MoveDown()
        {
            var downEntity = (Property)Provider.Database.Read(this.GetType(), "PropertySetId = {0} AND OrderNo={1}", PropertySetId, OrderNo + 1);
            if (downEntity == null)
                return;

            if (downEntity.GroupName != this.GroupName)
            {
                Provider.Database.ExecuteNonQuery("update Property set OrderNo = OrderNo - {2} where PropertySetId = {0} AND GroupName={1}", PropertySetId, downEntity.GroupName, Provider.Database.GetInt("select count(*) from Property where PropertySetId = {0} AND GroupName={1}", PropertySetId, this.GroupName));
                Provider.Database.ExecuteNonQuery("update Property set OrderNo = OrderNo + {2} where PropertySetId = {0} AND GroupName={1}", PropertySetId, this.GroupName, Provider.Database.GetInt("select count(*) from Property where PropertySetId = {0} AND GroupName={1}", PropertySetId, downEntity.GroupName));
            }
            else
            {
                downEntity.OrderNo--;
                downEntity.Save();

                this.OrderNo++;
                this.Save();
            }
        }
    }

    public class ListViewProperty : Property
    {
        public string PropertySetName { get; set; }
    }
}