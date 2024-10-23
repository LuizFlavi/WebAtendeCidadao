namespace WebAtendeCidadao.Models
{
    public class Login
    {
        public string email { get; set; }

        public string senha { get; set; }

        public class Usuario
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Senha { get; set; }
        }

        public class LoginResponse
        {

            public string Token { get; set; }

            public Usuario User { get; set; }
        }
    }
}
                    

    

