using AutoMapper;

namespace AgiliFood.AutoMapper
{
    /// <summary>
    /// Classe responsavel por inicializar o mapeamento das camadas dominio com view model
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// </remarks>
    public class AutoMapperConfig
    {
        public static void RegistrarMapeamentos()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<AutoMapperProfile>();
            });
        }
    }
}