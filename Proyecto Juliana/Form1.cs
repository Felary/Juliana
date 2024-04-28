﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Juliana
{
    public partial class Juego : Form
    {
        //Variables para el juego
        int vidas = 3, puntuacion = 0;
        //Instanciar la clase SoundPlayer
        SoundPlayer muerte = new SoundPlayer(@"e:\sonidos\freno.wav"); //Cambiar ruta según la ubicación del archivo
        public Juego()
        {
            InitializeComponent();
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
            paredIzquierda(imgOvni4Abajo);
            paredIzquierda(imgOvni5Abajo);
            paredIzquierda(imgOvni6Abajo);
            paredIzquierda(imgOvni7Abajo);

            //Incrementar la puntuación
            puntuacion++;
            //Mostrar la puntuación
            txtPuntuacion.Text = "Puntuación: " + puntuacion;
            //Llamar al método para detectar la colisión de las naves
            colicionNaves();

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
        private void paredDerecha(PictureBox imagen) //Funcion para detectar la pared derecha
        {
            //Si la imagen llega a la pared derecha se muestra en el otro extremo
            if (imagen.Left >= 970)
            {
                //Se cambia la posición de la imagen
                imagen.Location = new Point(-50, imagen.Location.Y);
            }

        }
        private void paredIzquierda(PictureBox imagen) //Funcion para detectar la pared izquierda
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
        }
        private void colicionRespuestas() //Metodo para detectar la colisión de las respuestas
        {
            //Si bender colisiona con una respuesta se suma 200 puntos y se reposiciona bender
            if (imgBender.Bounds.IntersectsWith(imgRespuesta1.Bounds))
            {
                //Se suma 200 puntos a la puntuación
                puntuacion += 200;
                //Se cambia la ubicacion de bender
                imgBender.Location = new Point(780, 622);

            }

        }
        private void colicionPreguntas() //Metodo para detectar la colisión de las preguntas
        {

            if (imgBender.Bounds.IntersectsWith(imgPregunta.Bounds))
            {

            }
        }

    }
}

