namespace Machado_Games.Security
{
    public class Settings
    {
        private static string secret = "e42cc80b79d1125a831c55aa6c306929c362cf5d371df54a02718b9b167746fa";

        public static string Secret {get => secret; set => secret = value;}
    }
}