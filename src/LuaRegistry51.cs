namespace KeraLua
{
    /// <summary>
    /// Enum for pseudo-index used by registry table
    /// </summary>
    public enum LuaRegistry
    {
        /* LUAI_MAXSTACK		1000000 */
        /// <summary>
        /// pseudo-index used by registry table
        /// </summary>
        Index = NativeMethods.LUA_REGISTRYINDEX
    }

    /// <summary>
    /// Registry index 
    /// </summary>
    public enum LuaRegistryIndex
    {
        /// <summary>
        ///  At this index the registry has the main thread of the state.
        /// </summary>
        MainThread = 1,
        /// <summary>
        /// At this index the registry has the global environment. 
        /// </summary>
        Globals = 2,
    }
}
