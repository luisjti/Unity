using System;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.DoorNKey
{
    internal class GerenciadorDeNivel
    {

        public static void CarregaProximoNivel()
        {
            var cenaAtual = SceneManager.GetActiveScene().name;

            if ("Nivel_Zero".Equals(cenaAtual))
            {
                SceneManager.LoadScene("Nivel_Um");
            }
            else if (("Nivel_Um").Equals(cenaAtual))
            {
                SceneManager.LoadScene("Nivel_Chefao");
            }else if ("Nivel_Chefao".Equals(cenaAtual))
            {
                SceneManager.LoadScene("MenuInicial");
            }
        }

        public static  void ReinicarNivel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
}
