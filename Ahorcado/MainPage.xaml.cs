using Microsoft.Maui.Animations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ahorcado
{
    public partial class MainPage : ContentPage
    {
        public string ImagenActiva { get; set; } = "C:\\Users\\cayet\\source\\repos\\Ahorcado\\Ahorcado\\Resources\\Images\\img0.jpg";
        public List<string> Palabras { get; set; } = ["ENERO","FEBRERO","MARZO","ABRIL","MAYO","JUNIO","JULIO","AGOSTO","SEPTIEMBRE","OCTUBRE","NOVIEMBRE","DICIEMBRE"];
        public List<string> Letras { get; set; } = ["A","B","C","D","E","F","G","H","I","J","K","L","M","N","Ñ","O","P","Q","R","S","T","U","V","W","X","Y","Z"];
        public string PalabraActual { get; set; } = "";
        public int Fallos { get; set; } = 0;
        const int MAXIMO = 6;
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
            GenerarPalabraAleatoria();
            PintarPalabra();
            CrearBotones();
        }

        //PALABRA RANDOM
        private void GenerarPalabraAleatoria()
        {
            Random random = new Random();
            int indiceAleatorio = random.Next(0, Palabras.Count);
            string palabraAleatoria = Palabras[indiceAleatorio];
            PalabraActual = palabraAleatoria;
        }


        //PARA GENERAR LA PALABRA
        private void PintarPalabra()
        {
            foreach (var guion in PalabraActual)
            {
                Label letra = new Label
                {
                    Text = "__",
                    Margin = new Thickness(5),
                    FontSize = 50,
                    WidthRequest = 70,
                    HeightRequest = 70,
                    TextColor = new Color(256,256,256)
                };
                LblPalabra.Add(letra);
            }

        }

        //PARA CREAR LAS LETRAS
        private void CrearBotones()
        {
            foreach (string letra in Letras)
            {
                Button boton = new Button
                {
                    Text = letra.ToString(),
                    Margin = new Thickness(5),
                    FontSize = 50,
                    WidthRequest = 70,
                    HeightRequest = 70,
                };
                boton.Clicked += BotonLetraClicked;
                BtnLetras.Add(boton);
            }
        }

        //EVENTO TECLAS
        private void BotonLetraClicked(object sender, EventArgs e)
        {
            bool esta = false;
            Label correcto;
            if (sender is Button boton)
            {
                string letraSeleccionada = boton.Text;
                for (global::System.Int32 i = 0; i < PalabraActual.Length; i++)
                {
                    if (string.Equals(letraSeleccionada, PalabraActual[i].ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        if (LblPalabra.Children.Count > i && LblPalabra.Children[i] is Label aux)
                        {
                            aux.Text = letraSeleccionada;
                            esta = true;
                        }
                    }
                }
                if (!esta)
                {
                    Fallos++;
                    CambiarImagen(Fallos);
                }
                boton.IsEnabled = false;
            }
        }

        //CAMBIAR MUÑECO
        private void CambiarImagen(int numero)
        {
            switch (numero)
            {
                case 1:
                    Foto.Source = "C:\\Users\\cayet\\source\\repos\\Ahorcado\\Ahorcado\\Resources\\Images\\img1.jpg";
                    break;
                case 2:
                    Foto.Source = "C:\\Users\\cayet\\source\\repos\\Ahorcado\\Ahorcado\\Resources\\Images\\img2.jpg";
                    break;
                case 3:
                    Foto.Source = "C:\\Users\\cayet\\source\\repos\\Ahorcado\\Ahorcado\\Resources\\Images\\img3.jpg";
                    break;
                case 4:
                    Foto.Source = "C:\\Users\\cayet\\source\\repos\\Ahorcado\\Ahorcado\\Resources\\Images\\img4.jpg";
                    break;
                case 5:
                    Foto.Source = "C:\\Users\\cayet\\source\\repos\\Ahorcado\\Ahorcado\\Resources\\Images\\img5.jpg";
                    break;
                case 6:
                    Foto.Source = "C:\\Users\\cayet\\source\\repos\\Ahorcado\\Ahorcado\\Resources\\Images\\img6.jpg";
                    break;
            }
        }

    }

}
