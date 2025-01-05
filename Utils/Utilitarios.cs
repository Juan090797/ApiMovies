namespace ApiMovies.Utils
{
    public class Utilitarios
    {
        //metodo para encriptar contraseña
        public static string EncriptarPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "";
            }
            else
            {
                //return BCrypt.Net.BCrypt.HashPassword(password);
                return "";
            }
        }
    }
}
