namespace PP.Aplication.ConectionString
{
    public static class ConectionString
    {
        #region Conexion de Augusto
        //const string Servidor = @"DESKTOP-I9AA7DR\SQLEXPRESS";
        //const string BaseDatos = "BaseEventManager";
        #endregion

        #region Conexion de Federico
        //const string Servidor = @"LAPTOP-JB193POB\SQLEXPRESS";
        //const string BaseDatos = "3LabBase";
        #endregion

        #region Conexion de Mauro
        const string Servidor = @"LAPTOP-31N6BQDF\SQLEXPRESS";
        const string BaseDatos = "ManagerEvent";
        #endregion


        public static string GetWithWindows => $"Data Source={Servidor}; " +
                             $"Initial Catalog={BaseDatos}; " +
                             $"Integrated Security=True;";
    }
}
