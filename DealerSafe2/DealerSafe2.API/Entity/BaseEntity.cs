﻿using System;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;
using System.Reflection;
using Cinar.Database;
using DealerSafe2.API.Entity.Common;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Entity
{
    public abstract class BaseEntity : IDatabaseEntityMinimal
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12, IsNotNull = true, IsPrimaryKey = true)]
        public string Id { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual void BeforeSave(bool isUpdate)
        {
            Validate();
        }

        public virtual void Save()
        {
            try
            {
                Provider.Database.Begin();

                var tbl = Provider.Database.CheckTableExistance(this);

                bool isUpdate = !this.Id.IsEmpty();

                this.BeforeSave(isUpdate);

                if (!isUpdate)
                {
                    string id = "";
                    while (true)
                    {
                        id = Utility.CreatePassword(12);
                        if (Provider.Database.Read(this.GetType(), "Id={0}", id) == null)
                            break;
                        id = "";
                    }
                    this.Id = id;
                    this.InsertDate = Provider.Database.Now;

                    Provider.Database.Insert(this.GetType().Name, Provider.Database.EntityToHashtable(this));
                }
                else
                {
                    if(Provider.Database.Read(this.GetType(), "Id={0}", this.Id)!=null)
                        Provider.Database.Update(tbl.Name, Provider.Database.EntityToHashtable(this));
                    else
                        Provider.Database.Insert(this.GetType().Name, Provider.Database.EntityToHashtable(this));
                }
                this.AfterSave(isUpdate);

                Provider.Database.Commit();
            }
            catch (Exception ex)
            {
                Provider.Database.Rollback();
                throw new CinarException(ex);
            }
        }

        public void Insert() 
        {
            if (this.Id.IsEmpty()) 
            {
                this.Save();
                return; //***
            }

            try
            {
                Provider.Database.Begin();

                var tbl = Provider.Database.CheckTableExistance(this);

                this.BeforeSave(false);

                bool isUpdate = false;

                if (!isUpdate)
                {
                    this.InsertDate = Provider.Database.Now;

                    Provider.Database.Insert(this.GetType().Name, Provider.Database.EntityToHashtable(this));
                }

                this.AfterSave(isUpdate);

                Provider.Database.Commit();
            }
            catch (Exception ex)
            {
                Provider.Database.Rollback();
                throw new CinarException(ex);
            }
        }


        public virtual void Validate()
        {
        }

        public virtual void Delete()
        {
            var tbl = Provider.Database.GetTableForEntityType(this.GetType());
            Provider.Database.ExecuteNonQuery("UPDATE [" + tbl.Name + "] SET IsDeleted=1 WHERE Id={0}", Id);
        }

        public override string ToString()
        {
            return Id;
        }

        public virtual void Initialize()
        {

        }

        public virtual void AfterSave(bool isUpdate)
        {
            #region if critical entity, log it
            if (this is ICriticalEntity)
            {
                if (isUpdate)
                {
                    //Provider.Database.ClearEntityWebCache(this.GetType(), this.Id);
                    IDatabaseEntityMinimal originalEntity = Provider.Database.Read(this.GetType(), "Id={0}", this.Id);
                    string changes = originalEntity.CompareFields(this);

                    if (!string.IsNullOrWhiteSpace(changes))
                    {
                        EntityHistory eh = new EntityHistory()
                            {
                                EntityId = this.Id,
                                EntityName = this.GetType().Name,
                                MemberId = Provider.CurrentMember.Id,
                                Operation = EntityOperation.Update
                            };
                        eh.Save();

                        EntityHistoryData ehd = new EntityHistoryData()
                            {
                                Changes = changes,
                                EntityHistoryId = eh.Id
                            };
                        ehd.Save();
                    }
                }
                else
                {
                    EntityHistory eh = new EntityHistory()
                    {
                        EntityId = this.Id,
                        EntityName = this.GetType().Name,
                        MemberId = Provider.CurrentMember.Id,
                        Operation = EntityOperation.Insert
                    };
                    eh.Save();
                }
            }
            #endregion
        }


        public virtual string GetNameColumn()
        {
            return "";
        }
        public virtual string GetNameValue()
        {
            return "";
        }
        private Hashtable ht = new Hashtable();
        public object this[string key]
        {
            get
            {
                return ht[key];
            }
            set
            {
                ht[key] = value;
            }
        }
        public Hashtable GetOriginalValues()
        {
            return ht;
        }

        /// <summary>
        /// Use this method such as: entity.SetFieldsByPostData(Request.Form);
        /// </summary>
        /// <param name="postData"></param>
        public virtual void SetFieldsByPostData(NameValueCollection postData)
        {
            for (int i = 0; i < postData.Count; i++)
            {
                PropertyInfo pi = this.GetType().GetProperty(postData.GetKey(i));
                if (pi == null || pi.GetSetMethod() == null) continue;

                string strVal = postData[i];

                if (pi.PropertyType == typeof(bool))
                {
                    if (strVal.ToLower() == "1") strVal = "True";
                    if (strVal.ToLower() == "0") strVal = "False";
                    if (strVal.ToLower() != "true") strVal = "False";
                }

                object val = null;
                try
                {
                    if (pi.PropertyType.IsEnum)
                        val = Enum.Parse(pi.PropertyType, strVal);
                    else
                        val = strVal.ChangeType(pi.PropertyType, CultureInfo.CurrentCulture);
                }
                catch
                {
                    throw new Exception(string.Format("The field {0} cannot have {1} as value.", this.GetType().Name + "." + pi.Name, strVal));
                }

                pi.SetValue(this, val, null);
            }
            for (int i = 0; i < postData.Count; i++)
            {
                string key = postData.GetKey(i);
                if (!this.ht.ContainsKey(key)) continue;
                this.ht[key] = postData[i];
            }
        }

        //protected bool crudDoneByAPI = false;
    }

    public interface ICriticalEntity
    {
    }
}