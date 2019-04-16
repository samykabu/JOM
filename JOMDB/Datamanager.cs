
namespace JOMDB
{
    public sealed class Datamanager
    {
        private static Datamanager instance = null;
        static readonly object padlock = new object();

        private Datamanager()
        {
            _JOMDBInstance = new JOMDBEntities("metadata=res://*/JOMDBModel.csdl|res://*/JOMDBModel.ssdl|res://*/JOMDBModel.msl;provider=System.Data.SqlServerCe.3.5;provider connection string=\"Data Source=F:\\JOM\\JOMSQLDB.sdf;Password=p7z6y1f9;Persist Security Info=false\";");
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


        private JOMDBEntities _JOMDBInstance;
        public JOMDBEntities DatabaseEntities
        {
            get
            {
                return _JOMDBInstance;
            }
        }
    }
}
