// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using PP.Dominio.Repositorio.Banco;
using PP.Dominio.Repositorio.ClientePagina;
using PP.Dominio.Repositorio.Configuracion;
using PP.Dominio.Repositorio.Detalle;
using PP.Dominio.Repositorio.Entrada;
using PP.Dominio.Repositorio.Evento;
using PP.Dominio.Repositorio.Factura;
using PP.Dominio.Repositorio.FechaEvento;
using PP.Dominio.Repositorio.FormaPago;
using PP.Dominio.Repositorio.FP_Tarjeta;
using PP.Dominio.Repositorio.FP_Transferencia;
using PP.Dominio.Repositorio.Inscripcion;
using PP.Dominio.Repositorio.Localidad;
using PP.Dominio.Repositorio.PlanTarjeta;
using PP.Dominio.Repositorio.PreguntaFrecuente;
using PP.Dominio.Repositorio.Provincia;
using PP.Dominio.Repositorio.Tarjeta;
using PP.Dominio.Repositorio.TipoEvento;
using PP.Dominio.Repositorio.Ubicacion;
using PP.Dominio.Repositorio.Usuario;
using PP.IServicio.Banco;
using PP.IServicio.Configuracion;
using PP.IServicio.Detalle;
using PP.IServicio.Entrada;
using PP.IServicio.Evento;
using PP.IServicio.Factura;
using PP.IServicio.FechaEvento;
using PP.IServicio.FormaPago;
using PP.IServicio.FP_Tarjeta;
using PP.IServicio.FP_Transferencia;
using PP.IServicio.Inscripcion;
using PP.IServicio.Localidad;
using PP.IServicio.PaginaCliente;
using PP.IServicio.PlanTarjeta;
using PP.IServicio.PreguntaFrecuente;
using PP.IServicio.Provincia;
using PP.IServicio.Tarjeta;
using PP.IServicio.TipoEvento;
using PP.IServicio.Ubicacion;
using PP.IServicio.Usuario;
using PP.Servicio.Banco;
using PP.Servicio.ClientePagina;
using PP.Servicio.Configuracion;
using PP.Servicio.Detalle;
using PP.Servicio.Entrada;
using PP.Servicio.Evento;
using PP.Servicio.Factura;
using PP.Servicio.FechaEvento;
using PP.Servicio.FormaPago;
using PP.Servicio.FP_Tarjeta;
using PP.Servicio.FP_Transferencia;
using PP.Servicio.Inscripcion;
using PP.Servicio.Localidad;
using PP.Servicio.PlanTarjeta;
using PP.Servicio.PreguntaFrecuente;
using PP.Servicio.Provincia;
using PP.Servicio.Tarjeta;
using PP.Servicio.TipoEvento;
using PP.Servicio.Ubicacion;
using PP.Servicio.Usuario;

namespace WebAplicationApi.DependencyResolution {
    using PP.Dominio.Repositorio.Pais;
    using PP.InfraestructuraRepositorio;
    using PP.IServicio.Pais;
    using PP.Servicio.Pais;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            //For<IExample>().Use<Example>();
            For<IPaisServicio>().Use<PaisServicio>();
            For<IPaisRepositorio>().Use<PaisRepositorio>();

            For<IProvinciaServicio>().Use<ProvinciaServicio>();
            For<IProvinciaRepositorio>().Use<ProvinciaRepositorio>();

            For<IEntradaServicio>().Use<EntradaServicio>();
            For<IEntradaRepositorio>().Use<EntradaRepositorio>();
            
            For<IFacturaServicio>().Use<FacturaServicio>();
            For<IFacturaRepositorio>().Use<FacturaRepositorio>();
            
            For<IDetalleServicio>().Use<DetalleServicio>();
            For<IDetalleRepositorio>().Use<DetalleRepositorio>();
            
            For<IFechaEventoServicio>().Use<FechaEventoServicio>();
            For<IFechaEventoRepositorio>().Use<FechaEventoRepositorio>();

            For<IUbicacionServicio>().Use<UbicacionServicio>();
            For<IUbicacionRepositorio>().Use<UbicacionRepositorio>();
            
            For<ILocalidadServicio>().Use<LocalidadServicio>();
            For<ILocalidadRepositorio>().Use<LocalidadRepositorio>();
            
            For<IClientePaginaServicio>().Use<ClientePaginaServicio>();
            For<IClientePaginaRepositorio>().Use<ClientePaginaRepositorio>();
            
            For<IUsuarioServicio>().Use<UsuarioServicio>();
            For<IUsuarioRepositorio>().Use<UsuarioRepositorio>();

            For<IFormaPagoServicio>().Use<FormaPagoServicio>();
            For<IFormaPagoRepositorio>().Use<FormaPagoRepositorio>();
            
            For<IFP_TarjetaServicio>().Use<FP_TarjetaServicio>();
            For<IFP_TarjetaRepositorio>().Use<FP_TarjetaRepositorio>();
            
            For<IFP_TransferenciaServicio>().Use<FP_TransferenciaServicio>();
            For<IFP_TransferenciaRepositorio>().Use<FP_TransferenciaRepositorio>();
            
            For<IPlanTarjetaServicio>().Use<PlanTarjetaServicio>();
            For<IPlanTarjetaRepositorio>().Use<PlanTarjetaRepositorio>();
            
            For<ITarjetaServicio>().Use<TarjetaServicio>();
            For<ITarjetaRepositorio>().Use<TarjetaRepositorio>();
            
            For<IBancoServicio>().Use<BancoServicio>();
            For<IBancoRepositorio>().Use<BancoRepositorio>();
            
            For<IEventoServicio>().Use<EventoServicio>();
            For<IEventoRepositorio>().Use<EventoRepositorio>();
            
            For<ITipoEventoServicio>().Use<TipoEventoServicio>();
            For<ITipoEventoRepositorio>().Use<TipoEventoRepositorio>();
            
            For<IPreguntaFrecuenteServicio>().Use<PreguntaFrecuenteServicio>();
            For<IPreguntaFrecuenteRepositorio>().Use<PreguntaFrecuenteRepositorio>();
            
            For<IConfiguracionServicio>().Use<ConfiguracionServicio>();
            For<IConfiguracionRepositorio>().Use<ConfiguracionRepositorio>();

            For<IInscripcionServicio>().Use<InscripcionServicio>();
            For<IInscripcionRepositorio>().Use<InscripcionRepositorio>();
        }

        #endregion
    }
}