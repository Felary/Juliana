using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_Juliana
{
    public partial class Juego : Form
    {
        //Se crea una matriz de 1x1 para guardar la pregunta y la respuesta
        string[,] cuestionario = new string[2, 5];
        //Variables para el juego
        int vidas = 3, puntuacion = 0, pregunta = 0;
        //Instanciar la clase SoundPlayer
        SoundPlayer muerte = new SoundPlayer(@"d:\sonidos\muerte.wav"); //Cambiar ruta según la ubicación del archivo
        SoundPlayer sonidoPregunta; //Cambiar ruta según la ubicación del archivo
        public Juego()
        {
            InitializeComponent();
            //Se llama al método para llenar el cuestionario
            llenarCuestionario();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //Llamar al método para mover las imágenes
            moverImagenes();
            //Llamar al método para detectar la pared derecha
            paredDerecha(imgOvni1Arriba);
            paredDerecha(imgOvni2Arriba);
            paredDerecha(imgOvni3Arriba);
            paredDerecha(imgOvni4Arriba);
            paredDerecha(imgOvni1Abajo);
            paredDerecha(imgOvni2Abajo);
            paredDerecha(imgOvni3Abajo);

            //Llamar al método para detectar la pared izquierda
            paredIzquierda(imgRespuesta1);
            paredIzquierda(imgRespuesta2);
            paredIzquierda(imgRespuesta3);
            paredIzquierda(imgRespuesta4);
            paredIzquierda(imgRespuesta5);

            paredIzquierda(imgOvni4Abajo);
            paredIzquierda(imgOvni5Abajo);
            paredIzquierda(imgOvni6Abajo);
            paredIzquierda(imgOvni7Abajo);

            //Incrementar la puntuación
            puntuacion++;
            //Mostrar la puntuación
            txtPuntuacion.Text = "" + puntuacion;
            //Llamar al método para detectar la colisión de las naves
            colicionNaves();
            //Llamar al método para detectar la colisión de las preguntas
            colicionPreguntas();

            //Llamar al método para detectar la colisión de las respuestas
            colicionRespuestas();
            //Se llama al metodo finJuego
            finJuego();
        }
        private void moverImagenes() //Método para mover las imágenes
        {
            //Mover las imágenes de arriba de izquierda a derecha
            imgOvni1Arriba.Left = imgOvni1Arriba.Left + 10;
            imgOvni2Arriba.Left = imgOvni2Arriba.Left + 10;
            imgOvni3Arriba.Left = imgOvni3Arriba.Left + 10;
            imgOvni4Arriba.Left = imgOvni4Arriba.Left + 10;

            //Mover las imágenes de las respuestas de derecha a izquierda
            imgRespuesta1.Left = imgRespuesta1.Left - 10;
            imgRespuesta2.Left = imgRespuesta2.Left - 10;
            imgRespuesta3.Left = imgRespuesta3.Left - 10;
            imgRespuesta4.Left = imgRespuesta4.Left - 10;
            imgRespuesta5.Left = imgRespuesta5.Left - 10;

            //Mover las imágenes de abajo de izquierda a derecha
            imgOvni1Abajo.Left = imgOvni1Abajo.Left + 10;
            imgOvni2Abajo.Left = imgOvni2Abajo.Left + 10;
            imgOvni3Abajo.Left = imgOvni3Abajo.Left + 10;

            //mover las imagenes de abajo de derecha a izquierda
            imgOvni4Abajo.Left = imgOvni4Abajo.Left - 10;
            imgOvni5Abajo.Left = imgOvni5Abajo.Left - 10;
            imgOvni6Abajo.Left = imgOvni6Abajo.Left - 10;
            imgOvni7Abajo.Left = imgOvni7Abajo.Left - 10;
        }
        private void paredDerecha(PictureBox imagen) //Metodo para detectar la pared derecha
        {
            //Si la imagen llega a la pared derecha se muestra en el otro extremo
            if (imagen.Left >= 970)
            {
                //Se cambia la posición de la imagen
                imagen.Location = new Point(-50, imagen.Location.Y);
            }

        }
        private void paredIzquierda(PictureBox imagen) //Metodo para detectar la pared izquierda
        {
            //Si la imagen llega a la pared izquierda se muestra en el otro extremo
            if (imagen.Left <= -50)
            {
                //Se cambia la posición de la imagen
                imagen.Location = new Point(970, imagen.Location.Y);
            }
        }
        private void colicionNaves() //Metodo para detectar la colisión de las naves
        {
            //si bender colisiona con una nave se muestra la imagen de bender destruido, se quita una vida y se reposiciona
            if (imgBender.Bounds.IntersectsWith(imgOvni1Abajo.Bounds))
            {
                //Se cambia la imagen de bender a bender destruido
                imgBender.Image = Properties.Resources.BenderMuerto;
                //Se llama al metodo para quitar una vida
                quitarVida();
                //Suena el sonido de muerte
                muerte.Play();
                //si las vidas son mayores a 0 bender vuelve a la posicion original
                if (vidas > 0)
                {
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);

                }
                else  //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //Se detiene el tiempo
                    timer.Stop();
                    //Suena el sonido de freno
                    muerte.Play();
                }
            }
            else if (imgBender.Bounds.IntersectsWith(imgOvni2Abajo.Bounds))
            {
                //Se cambia la imagen de bender a bender destruido
                imgBender.Image = Properties.Resources.BenderMuerto;
                //Se llama al metodo para quitar una vida
                quitarVida();
                //Suena el sonido de muerte
                muerte.Play();
                //si las vidas son mayores a 0 bender vuelve a la posicion original
                if (vidas > 0)
                {
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);

                }
                else  //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //Se detiene el tiempo
                    timer.Stop();
                    //Suena el sonido de freno
                    muerte.Play();
                }
            }
            else if (imgBender.Bounds.IntersectsWith(imgOvni3Abajo.Bounds))
            {
                //Se cambia la imagen de bender a bender destruido
                imgBender.Image = Properties.Resources.BenderMuerto;
                //Se llama al metodo para quitar una vida
                quitarVida();
                //Suena el sonido de muerte
                muerte.Play();
                //si las vidas son mayores a 0 bender vuelve a la posicion original
                if (vidas > 0)
                {
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);

                }
                else  //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //Se detiene el tiempo
                    timer.Stop();
                    //Suena el sonido de freno
                    muerte.Play();
                }
            }
            else if (imgBender.Bounds.IntersectsWith(imgOvni4Abajo.Bounds))
            {
                //Se cambia la imagen de bender a bender destruido
                imgBender.Image = Properties.Resources.BenderMuerto;
                //Se llama al metodo para quitar una vida
                quitarVida();
                //Suena el sonido de muerte
                muerte.Play();
                //si las vidas son mayores a 0 bender vuelve a la posicion original
                if (vidas > 0)
                {
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);

                }
                else  //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //Se detiene el tiempo
                    timer.Stop();
                    //Suena el sonido de freno
                    muerte.Play();
                }
            }
            else if (imgBender.Bounds.IntersectsWith(imgOvni5Abajo.Bounds))
            {
                //Se cambia la imagen de bender a bender destruido
                imgBender.Image = Properties.Resources.BenderMuerto;
                //Se llama al metodo para quitar una vida
                quitarVida();
                //Suena el sonido de muerte
                muerte.Play();
                //si las vidas son mayores a 0 bender vuelve a la posicion original
                if (vidas > 0)
                {
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);

                }
                else  //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //Se detiene el tiempo
                    timer.Stop();
                    //Suena el sonido de freno
                    muerte.Play();
                }
            }
            else if (imgBender.Bounds.IntersectsWith(imgOvni6Abajo.Bounds))
            {
                //Se cambia la imagen de bender a bender destruido
                imgBender.Image = Properties.Resources.BenderMuerto;
                //Se llama al metodo para quitar una vida
                quitarVida();
                //Suena el sonido de muerte
                muerte.Play();
                //si las vidas son mayores a 0 bender vuelve a la posicion original
                if (vidas > 0)
                {
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);

                }
                else  //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //Se detiene el tiempo
                    timer.Stop();
                    //Suena el sonido de freno
                    muerte.Play();
                }
            }
            else if (imgBender.Bounds.IntersectsWith(imgOvni7Abajo.Bounds))
            {
                //Se cambia la imagen de bender a bender destruido
                imgBender.Image = Properties.Resources.BenderMuerto;
                //Se llama al metodo para quitar una vida
                quitarVida();
                //Suena el sonido de muerte
                muerte.Play();
                //si las vidas son mayores a 0 bender vuelve a la posicion original
                if (vidas > 0)
                {
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);

                }
                else  //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //Se detiene el tiempo
                    timer.Stop();
                    //Suena el sonido de freno
                    muerte.Play();
                }
            }
            else if (imgBender.Bounds.IntersectsWith(imgOvni1Arriba.Bounds))
            {
                //Se cambia la imagen de bender a bender destruido
                imgBender.Image = Properties.Resources.BenderMuerto;
                //Se llama al metodo para quitar una vida
                quitarVida();
                //Suena el sonido de muerte
                muerte.Play();
                //si las vidas son mayores a 0 bender vuelve a la posicion original
                if (vidas > 0)
                {
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);

                }
                else  //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //Se detiene el tiempo
                    timer.Stop();
                    //Suena el sonido de freno
                    muerte.Play();
                }
            }
            else if (imgBender.Bounds.IntersectsWith(imgOvni2Arriba.Bounds))
            {
                //Se cambia la imagen de bender a bender destruido
                imgBender.Image = Properties.Resources.BenderMuerto;
                //Se llama al metodo para quitar una vida
                quitarVida();
                //Suena el sonido de muerte
                muerte.Play();
                //si las vidas son mayores a 0 bender vuelve a la posicion original
                if (vidas > 0)
                {
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);

                }
                else  //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //Se detiene el tiempo
                    timer.Stop();
                    //Suena el sonido de freno
                    muerte.Play();
                }
            }
            else if (imgBender.Bounds.IntersectsWith(imgOvni3Arriba.Bounds))
            {
                //Se cambia la imagen de bender a bender destruido
                imgBender.Image = Properties.Resources.BenderMuerto;
                //Se llama al metodo para quitar una vida
                quitarVida();
                //Suena el sonido de muerte
                muerte.Play();
                //si las vidas son mayores a 0 bender vuelve a la posicion original
                if (vidas > 0)
                {
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);

                }
                else  //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //Se detiene el tiempo
                    timer.Stop();
                    //Suena el sonido de freno
                    muerte.Play();
                }
            }
            else if (imgBender.Bounds.IntersectsWith(imgOvni4Arriba.Bounds))
            {
                //Se cambia la imagen de bender a bender destruido
                imgBender.Image = Properties.Resources.BenderMuerto;
                //Se llama al metodo para quitar una vida
                quitarVida();
                //Suena el sonido de muerte
                muerte.Play();
                //si las vidas son mayores a 0 bender vuelve a la posicion original
                if (vidas > 0)
                {
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);

                }
                else  //si las vidas son iguales a 0 se detiene el tiempo, suena el freno y se muestra la imagen de GAMEOVER
                {
                    //Se detiene el tiempo
                    timer.Stop();
                    //Suena el sonido de freno
                    muerte.Play();
                }
            }
        }
        private void quitarVida() //Metodo para quitar una vida
        {
            //Si bender colisiona con una nave se quita una vida
            switch (vidas)
            {
                case 1:
                    //Se cambia la imagen de la vida a vida perdida
                    imgVida3.Image = Properties.Resources.muerte;
                    break;
                case 2:
                    //Se cambia la imagen de la vida a vida perdida
                    imgVida2.Image = Properties.Resources.muerte;
                    break;
                case 3:
                    //Se cambia la imagen de la vida a vida perdida
                    imgVida1.Image = Properties.Resources.muerte;
                    break;
            }
            //Se decrementa la cantidad de vidas
            vidas--;
        }
        private void colicionRespuestas() //Metodo para detectar la colisión de las respuestas
        {

            if (imgBender.Bounds.IntersectsWith(imgRespuesta1.Bounds))
            {
                if (pregunta == 1)
                {
                    //Se incrementa la puntuación
                    puntuacion += 200;
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);
                    //Se reposiciona la imagen de la pregunta
                    imgPregunta.Location = new Point(173, 622);
                    //Se muestra la imagen de la pregunta
                    imgPregunta.Visible = true;
                    //Se incrementa la variable pregunta
                    pregunta++;
                    //Se oculta la pregunta
                    txtPregunta.Visible = false;

                    progressBar.Increment(20);
                    lblRespuesta.Text = "CORRECTO";
                    lblRespuesta.Visible = true;
                }
                else
                {
                    //Se decrementa la puntuación
                    puntuacion -= 200;
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);
                    //Se reposiciona la imagen de la pregunta
                    imgPregunta.Location = new Point(173, 622);
                    //Se muestra la imagen de la pregunta
                    imgPregunta.Visible = true;
                    lblRespuesta.Text = "INCORRECTO";
                    lblRespuesta.Visible = true;
                }
            }
            if (imgBender.Bounds.IntersectsWith(imgRespuesta2.Bounds))
            {

                if (pregunta == 0)
                {
                    //Se incrementa la puntuación
                    puntuacion += 200;
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);
                    //Se reposiciona la imagen de la pregunta
                    imgPregunta.Location = new Point(173, 622);
                    //Se muestra la imagen de la pregunta
                    imgPregunta.Visible = true;
                    //Se incrementa la variable pregunta
                    pregunta++;
                    //Se oculta la pregunta
                    txtPregunta.Visible = false;

                    progressBar.Increment(20);
                    lblRespuesta.Text = "CORRECTO";
                    lblRespuesta.Visible = true;
                }
                else
                {
                    //Se decrementa la puntuación
                    puntuacion -= 200;
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);
                    //Se reposiciona la imagen de la pregunta
                    imgPregunta.Location = new Point(173, 622);
                    //Se muestra la imagen de la pregunta
                    imgPregunta.Visible = true;
                    lblRespuesta.Text = "INCORRECTO";
                    lblRespuesta.Visible = true;
                }
            }
            if (imgBender.Bounds.IntersectsWith(imgRespuesta3.Bounds))
            {

                if (pregunta == 2)
                {
                    //Se incrementa la puntuación
                    puntuacion += 200;
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);
                    //Se reposiciona la imagen de la pregunta
                    imgPregunta.Location = new Point(173, 622);
                    //Se muestra la imagen de la pregunta
                    imgPregunta.Visible = true;
                    //Se incrementa la variable pregunta
                    pregunta++;
                    //Se oculta la pregunta
                    txtPregunta.Visible = false;

                    progressBar.Increment(20);
                    lblRespuesta.Text = "CORRECTO";
                    lblRespuesta.Visible = true;
                }
                else
                {
                    //Se decrementa la puntuación
                    puntuacion -= 200;
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);
                    //Se reposiciona la imagen de la pregunta
                    imgPregunta.Location = new Point(173, 622);
                    //Se muestra la imagen de la pregunta
                    imgPregunta.Visible = true;
                    lblRespuesta.Text = "INCORRECTO";
                    lblRespuesta.Visible = true;
                }
            }
            if (imgBender.Bounds.IntersectsWith(imgRespuesta4.Bounds))
            {

                if (pregunta == 4)
                {
                    //Se incrementa la puntuación
                    puntuacion += 200;
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);
                    //Se reposiciona la imagen de la pregunta
                    imgPregunta.Location = new Point(173, 622);
                    //Se muestra la imagen de la pregunta
                    imgPregunta.Visible = true;
                    //Se incrementa la variable pregunta
                    pregunta++;
                    //Se oculta la pregunta
                    txtPregunta.Visible = false;

                    progressBar.Increment(20);
                    lblRespuesta.Text = "CORRECTO";
                    lblRespuesta.Visible = true;
                }
                else
                {
                    //Se decrementa la puntuación
                    puntuacion -= 200;
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);
                    //Se reposiciona la imagen de la pregunta
                    imgPregunta.Location = new Point(173, 622);
                    //Se muestra la imagen de la pregunta
                    imgPregunta.Visible = true;
                    lblRespuesta.Text = "INCORRECTO";
                    lblRespuesta.Visible = true;
                }
            }
            if (imgBender.Bounds.IntersectsWith(imgRespuesta5.Bounds))
            {

                if (pregunta == 3)
                {
                    //Se incrementa la puntuación
                    puntuacion += 200;
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);
                    //Se reposiciona la imagen de la pregunta
                    imgPregunta.Location = new Point(173, 622);
                    //Se muestra la imagen de la pregunta
                    imgPregunta.Visible = true;
                    //Se incrementa la variable pregunta
                    pregunta++;
                    //Se oculta la pregunta
                    txtPregunta.Visible = false;

                    progressBar.Increment(20);
                    lblRespuesta.Text = "CORRECTO";
                    lblRespuesta.Visible = true;
                }
                else
                {
                    //Se decrementa la puntuación
                    puntuacion -= 200;
                    //Se reposiciona la imagen de bender
                    imgBender.Location = new Point(780, 622);
                    //Se reposiciona la imagen de la pregunta
                    imgPregunta.Location = new Point(173, 622);
                    //Se muestra la imagen de la pregunta
                    imgPregunta.Visible = true;
                    lblRespuesta.Text = "INCORRECTO";
                    lblRespuesta.Visible = true;
                }
            }
        }
        private void colicionPreguntas() //Metodo para detectar la colisión de las preguntas
        {
            if (imgBender.Bounds.IntersectsWith(imgPregunta.Bounds) && imgPregunta.Location.X == 173 && imgPregunta.Location.Y == 622)
            {

                //Se cambia la ubicacion de la imagen de la pregunta
                imgPregunta.Location = new Point(811, 397);
                //Se muestra la pregunta
                txtPregunta.Visible = true;
                //Se muestra la pregunta en el label
                string color = txtPregunta.Text = cuestionario[1, pregunta];
                //Se llama al metodo para reproducir el sonido de la pregunta
                colicionSonido(color);
            }
            if (imgBender.Bounds.IntersectsWith(imgPregunta.Bounds) && imgPregunta.Location.X == 811 && imgPregunta.Location.Y == 397)
            {
                //Se cambia la ubicacion de la imagen de la pregunta
                imgPregunta.Location = new Point(168, 12);
                //Se oculta imgPregunta
                imgPregunta.Visible = false;
                //Se muestra la pregunta
                txtPregunta.Visible = true;
                //Se muestra la pregunta en el label
                string color = txtPregunta.Text = cuestionario[1, pregunta];
                //Se llama al metodo para reproducir el sonido de la pregunta
                colicionSonido(color);
            }
        }
        private void colicionSonido(string color)
        {
            switch (color)
            {
                case "BLUE":
                    sonidoPregunta = new SoundPlayer(@"d:\sonidos\BLUE.wav"); //Cambiar ruta según la ubicación del archivo
                    sonidoPregunta.Play();

                    imgRespuesta1.Image = Properties.Resources._1;
                    imgRespuesta2.Image = Properties.Resources._0; //CORRECTA
                    imgRespuesta3.Image = Properties.Resources._2;
                    imgRespuesta4.Image = Properties.Resources._4;
                    imgRespuesta5.Image = Properties.Resources._3;


                    break;
                case "RED":
                    sonidoPregunta = new SoundPlayer(@"d:\sonidos\RED.wav"); //Cambiar ruta según la ubicación del archivo
                    sonidoPregunta.Play();

                    imgRespuesta1.Image = Properties.Resources._1; //CORRECTA
                    imgRespuesta2.Image = Properties.Resources._4;
                    imgRespuesta3.Image = Properties.Resources._3;
                    imgRespuesta4.Image = Properties.Resources._2;
                    imgRespuesta5.Image = Properties.Resources._0;
                    break;
                case "BLACK":
                    sonidoPregunta = new SoundPlayer(@"d:\sonidos\BLACK.wav"); //Cambiar ruta según la ubicación del archivo
                    sonidoPregunta.Play();

                    imgRespuesta1.Image = Properties.Resources._1;
                    imgRespuesta2.Image = Properties.Resources._0;
                    imgRespuesta3.Image = Properties.Resources._2; //CORRECTA
                    imgRespuesta4.Image = Properties.Resources._3;
                    imgRespuesta5.Image = Properties.Resources._4;
                    break;
                case "GREEN":
                    sonidoPregunta = new SoundPlayer(@"d:\sonidos\GREEN.wav"); //Cambiar ruta según la ubicación del archivo
                    sonidoPregunta.Play();
                    imgRespuesta1.Image = Properties.Resources._4;
                    imgRespuesta2.Image = Properties.Resources._2;
                    imgRespuesta3.Image = Properties.Resources._1;
                    imgRespuesta4.Image = Properties.Resources._0;
                    imgRespuesta5.Image = Properties.Resources._3; //CORRECTA

                    break;
                case "PURPLE":
                    sonidoPregunta = new SoundPlayer(@"d:\sonidos\PURPLE.wav"); //Cambiar ruta según la ubicación del archivo
                    sonidoPregunta.Play();
                    imgRespuesta1.Image = Properties.Resources._0;
                    imgRespuesta2.Image = Properties.Resources._2;
                    imgRespuesta3.Image = Properties.Resources._3;
                    imgRespuesta4.Image = Properties.Resources._4; //CORRECTA
                    imgRespuesta5.Image = Properties.Resources._1;
                    break;
            }

        } //Metodo para detectar la colisión de los sonidos
        private void llenarCuestionario() //Metodo para llenar el cuestionario
        {
            //Se llena el cuestionario con las preguntas y respuestas
            cuestionario[0, 0] = "0";
            cuestionario[1, 0] = "BLUE";

            cuestionario[0, 1] = "1";
            cuestionario[1, 1] = "RED";

            cuestionario[0, 2] = "2";
            cuestionario[1, 2] = "BLACK";

            cuestionario[0, 3] = "3";
            cuestionario[1, 3] = "GREEN";

            cuestionario[0, 4] = "4";
            cuestionario[1, 4] = "PURPLE";
        }
        private void Juego_KeyDown(object sender, KeyEventArgs e) //Evento para mover a bender
        {
            //Si se presiona la tecla derecha se mueve bender a la derecha
            if (e.KeyCode == Keys.Right)
            {
                //se incrementa la posicion de la rana en el eje X
                imgBender.Left += 10;
                //se muestra la imagen de bender mirando a la derecha
                imgBender.Image = Properties.Resources.BenderDerecha;
            }
            //Si se presiona la tecla izquierda se mueve bender a la izquierda
            if (e.KeyCode == Keys.Left)
            {
                //se decrementa la posicion de la rana en el eje X
                imgBender.Left -= 10;
                //se muestra la imagen de bender mirando a la izquierda
                imgBender.Image = Properties.Resources.BenderIzquierda;
            }
            //Si se presiona la tecla arriba se mueve bender hacia arriba
            if (e.KeyCode == Keys.Up)
            {
                //se decrementa la posicion de la rana en el eje Y
                imgBender.Top -= 10;
                //se muestra la imagen de bender mirando el frente
                imgBender.Image = Properties.Resources.BenderFrente;

            }
            //Si se presiona la tecla abajo se mueve bender hacia abajo
            if (e.KeyCode == Keys.Down)
            {
                //se incrementa la posicion de la rana en el eje Y
                imgBender.Top += 10;
                //se muestra la imagen de bender mirando hacia abajo
                imgBender.Image = Properties.Resources.BenderAtras;
            }
        }
        private void finJuego() //Metodo para finalizar el juego
        {
            //Si las vidas son iguales a 0 Se mostrara la ventana formMenu
            if (vidas == 0)
            {
                //Detiene el timer
                timer.Stop();
                //Muestra un cuadro de dialogo donde le pregunta al usuario si desea reinicar el juego y muestra la puntuacion
                MessageBox.Show("GAME OVER\nPuntuación: " + puntuacion, "GAME OVER", MessageBoxButtons.OK);

                //utiliza el return para salir del metodo
                return;
            }
            //Si el contador de preguntas es igual a 10
            if (pregunta == 5)
            {
                //Detiene el timer
                timer.Stop();

                //Muestra un cuadro de dialogo donde se felicita al usuario por haber superado el nively muestra la puntuacion
                MessageBox.Show("¡Felicidades! Has completado todas las preguntas\nPuntuación: " + puntuacion, "¡Felicidades!", MessageBoxButtons.OK);
                //utiliza el return para salir del metodo
                return;
            }

        }
    }
}

