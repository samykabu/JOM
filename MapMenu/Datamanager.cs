#region System Refrences

using MapMenu;

#endregion

namespace JOMDB
{
    public sealed class Datamanager
    {
        private static readonly object padlock = new object();
        private static Datamanager instance;
        private JOMSQLDBEntities _JOMDBInstance;

        private Datamanager()
        {
            _JOMDBInstance =
                new JOMSQLDBEntities();//"metadata=res://*/JOMDBModel.csdl|res://*/JOMDBModel.ssdl|res://*/JOMDBModel.msl;provider=System.Data.SqlServerCe.3.5;provider connection string=\"Data Source=C:\\JOM\\JOMSQLDB.sdf;Password=p7z6y1f9;Persist Security Info=false\";");
        }

        public static Datamanager DataBase
        {
            get
            {
                if (instance == null)
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Datamanager();
                        }
                    }
                return instance;
            }
        }


        ///<summary>
        ///</summary>
        public JOMSQLDBEntities DatabaseEntities
        {
            get { return _JOMDBInstance; }
        }
    }
}