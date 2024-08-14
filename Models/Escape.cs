namespace PrimerProyecto.Models;

    public static class Escape
    {
        private static string[] incognitasSalas;
        private static int estadoJuego = 1;

        static Escape()
        {
            InicializarJuego();
        }

        private static void InicializarJuego()
        {
            incognitasSalas = new string[] { "alejandro garnacho", "gianluigi buffon", "skibidi rashford", "cucurella" };
        }

        public static int GetEstadoJuego()
        {
            return estadoJuego;
        }

        public static bool ResolverSala(int sala, string incognita)
        {
            if (incognitasSalas == null || incognitasSalas.Length == 0)
                InicializarJuego();

            if (sala != estadoJuego)
                return false;

            if (incognita == incognitasSalas[sala - 1])
            {
                estadoJuego++;
                return true;
            }

            return false;
        }
    }
