using ERPManagementAPP.Maintain;
using System.Collections;

namespace ERPManagementAPP.Modules
{
    public class MaintainModule
    {
        static MaintainModule instance;
        MaintainCollection collection;
        Field4MaintainControl currentControl;           // 當前選定的控制項
        Field4MaintainControl lastControl;              // 前一次的操作

        static MaintainModule()
        {
            instance = new MaintainModule();
        }

        public MaintainModule()
        {
            collection = new MaintainCollection();
            currentControl = null;
        }
        public MaintainCollection Collection { get { return collection; } }
        public static int Count { get { return instance.Collection.Count; } }
        public static Field4MaintainControl GetItem(int index) { return instance.Collection[index]; }
        public static Field4MaintainControl GetItem(string name) { return instance.Collection[name]; }

        public static Field4MaintainControl SelectItem(int index)
        {
            if (instance.currentControl != instance.Collection[index])
            {
                if (instance.lastControl != instance.Collection[index])
                {
                    instance.lastControl = instance.currentControl;
                    instance.currentControl = instance.Collection[index];
                }
                else
                {
                    #region Move lastControl to currentControl
                    var regControl = instance.currentControl;
                    instance.currentControl = instance.lastControl;
                    instance.lastControl = regControl;
                    #endregion
                }
            }
            if (instance.lastControl != null)
                instance.lastControl.Visible = false;
            return instance.Collection[index];
        }

        public static Field4MaintainControl SelectItem(string name)
        {
            if (instance.currentControl != instance.Collection[name])
            {
                if (instance.lastControl != instance.Collection[name])
                {
                    instance.lastControl = instance.currentControl;
                    instance.currentControl = instance.Collection[name];
                }
                else
                {
                    #region Move lastControl to currentControl
                    var regControl = instance.currentControl;
                    instance.currentControl = instance.lastControl;
                    instance.lastControl = regControl;
                    #endregion
                }
            }
            if (instance.lastControl != null)
                instance.lastControl.Visible = false;
            return instance.Collection[name];
        }
        public static MaintainModule Instance { get { return instance; } }
        public static Field4MaintainControl CurrentControl { get { return instance.currentControl; } }
        public static Field4MaintainControl LastControl { get { return instance.lastControl; } }
        public static void Add(Field4MaintainControl field4Maintain) { instance.collection.Add(field4Maintain); }
    }
    public class MaintainCollection : CollectionBase
    {
        public Field4MaintainControl this[int index]
        {
            get
            {
                if (List.Count > index)
                    return List[index] as Field4MaintainControl;
                return null;
            }
        }

        public Field4MaintainControl this[string name]
        {
            get
            {
                foreach (Field4MaintainControl MaintainControl in this)
                    if (MaintainControl.Name.Equals(name))
                        return MaintainControl;
                return null;
            }
        }

        public void Add(Field4MaintainControl value)
        {
            if (!List.Contains(value))
                List.Add(value);
        }

        public void Remove(Field4MaintainControl value)
        {
            if (List.Contains(value))
                List.Remove(value);
        }
    }

}
