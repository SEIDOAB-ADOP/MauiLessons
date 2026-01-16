using MauiLessons.Models;

namespace MauiLessons.Globals
{
    public class Global

    {
        #region singleton implementation
        private static Global _instance = null;
        Global() { } // just to avoid any direct instantiations
        public static Global Data => (_instance == null) ? _instance = new Global() : _instance;
        #endregion

        #region Data implementation 
        // accessible as Global.Message and Global.Time 
        public string Message { get; set;}
        public DateTime Time { get; set;}
        #endregion

        #region Lazy Data implementation 
        public Lazy<List<Friend>> Friends = new (() => Friend.Factory.CreateRandom(1000));
        public Lazy<IEnumerable<NamedColor>> NamedColors = new(() => NamedColor.All);
        #endregion
    }
}
