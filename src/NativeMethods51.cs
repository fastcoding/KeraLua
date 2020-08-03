﻿// ReSharper disable IdentifierTypo
using System.Runtime.InteropServices;
using System.Security;

using size_t = System.UIntPtr;
using lua_State = System.IntPtr;
using lua_CFunction = System.IntPtr;
using voidptr_t = System.IntPtr;
using charptr_t = System.IntPtr;
using lua_KContext = System.IntPtr;
using lua_KFunction = System.IntPtr;
using lua_Writer = System.IntPtr;
using lua_Reader = System.IntPtr;
using lua_Alloc = System.IntPtr;
using lua_Hook = System.IntPtr;
using lua_Integer = System.Int64;
using lua_Number = System.Double;
using lua_Number_ptr = System.IntPtr;
using lua_Debug = System.IntPtr;
using lua_WarnFunction = System.IntPtr;

namespace KeraLua
{
    [SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods
    {

#if __TVOS__ && __UNIFIED__
        private const string LuaLibraryName = "@rpath/liblua51.framework/liblua51";
#elif __WATCHOS__ && __UNIFIED__
        private const string LuaLibraryName = "@rpath/liblua51.framework/liblua51";
#elif __IOS__ && __UNIFIED__
        private const string LuaLibraryName = "@rpath/liblua51.framework/liblua51";
#elif __ANDROID__
        private const string LuaLibraryName = "liblua51.so";
#elif __MACOS__ 
        private const string LuaLibraryName = "liblua51.dylib";
#elif WINDOWS_UWP
        private const string LuaLibraryName = "lua51.dll";
#else
        private const string LuaLibraryName = "lua";
#endif

#pragma warning disable IDE1006 // Naming Styles
        internal const int LUA_REGISTRYINDEX = (-10000);
        internal const int LUA_ENVIRONINDEX = (-10001);
        internal const int LUA_GLOBALSINDEX = (-10002);
        /*[DllImport (LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_absindex(lua_State luaState, int idx);
        
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_arith(lua_State luaState, int op);
        */
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_CFunction lua_atpanic(lua_State luaState, lua_CFunction panicf);

        /*[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_callk(lua_State luaState, int nargs, int nresults, lua_KContext ctx, lua_KFunction k);
        */

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_checkstack(lua_State luaState, int extra);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_close(lua_State luaState);

        /*[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_compare(lua_State luaState, int index1, int index2, int op);
        */
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_concat(lua_State luaState, int n);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_copy(lua_State luaState, int fromIndex, int toIndex);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_createtable(lua_State luaState, int elements, int records);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_dump(lua_State luaState, lua_Writer writer, voidptr_t data, int strip);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_error(lua_State luaState);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_gc(lua_State luaState, int what, int data);

        /*[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_gc(lua_State luaState, int what, int data, int data2);
        */
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_Alloc lua_getallocf(lua_State luaState, ref voidptr_t ud);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int lua_getfield(lua_State luaState, int index, string k);

        //[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static int lua_getglobal(lua_State luaState, string name)
        {
            lua_getfield(luaState, LUA_GLOBALSINDEX, (name));  //in 5.1 type void
            return lua_type(luaState, -1);
        }

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_Hook lua_gethook(lua_State luaState);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_gethookcount(lua_State luaState);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_gethookmask(lua_State luaState);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_geti(lua_State luaState, int index, long i);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int lua_getinfo(lua_State luaState, string what, lua_Debug ar);

       /* [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_getiuservalue(lua_State luaState, int idx, int n);
       */
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern charptr_t lua_getlocal(lua_State luaState, lua_Debug ar, int n);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_getmetatable(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_getstack(lua_State luaState, int level, lua_Debug n);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_gettable(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_gettop(lua_State luaState);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern charptr_t lua_getupvalue(lua_State luaState, int funcIndex, int n);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_iscfunction(lua_State luaState, int index);

        
        internal static int lua_isinteger(lua_State luaState, int index) {
            double d = lua_tonumber(luaState, index);
            System.IntPtr i = lua_tointeger(luaState, index);
            return (d - (double)(System.Int64)i)==0?1:0;
        }
        
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double lua_tonumber(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern System.IntPtr lua_tointeger(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_isnumber(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_isstring(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_isuserdata(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_isyieldable(lua_State luaState);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_objlen(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int lua_load
           (lua_State luaState,
            lua_Reader reader,
            voidptr_t data,
            string chunkName,
            string mode);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_State lua_newstate(lua_Alloc allocFunction, voidptr_t ud);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_State lua_newthread(lua_State luaState);

        /* [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
         internal static extern voidptr_t lua_newuserdatauv(lua_State luaState, size_t size, int nuvalue);
         */
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern voidptr_t lua_newuserdata(lua_State luaState, size_t size);
        
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_next(lua_State luaState, int index);

        /*[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_pcallk
            (lua_State luaState,
            int nargs,
            int nresults,
            int errorfunc,
            lua_KContext ctx,
            lua_KFunction k);
            */
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_call
           (lua_State luaState,
           int nargs,
           int nresults           
        );
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_pcall
            (lua_State luaState,
            int nargs,
            int nresults,
            int errorfunc
         );
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_pushboolean(lua_State luaState, int value);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_pushcclosure(lua_State luaState, lua_CFunction f, int n);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_pushinteger(lua_State luaState, lua_Integer n);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_pushlightuserdata(lua_State luaState, voidptr_t udata);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern charptr_t lua_pushlstring(lua_State luaState, byte [] s, size_t len);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_pushnil(lua_State luaState);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_pushnumber(lua_State luaState, lua_Number number);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_pushthread(lua_State luaState);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_pushvalue(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_rawequal(lua_State luaState, int index1, int index2);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_rawget(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_rawgeti(lua_State luaState, int index, lua_Integer n);

        /*[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_rawgetp(lua_State luaState, int index, voidptr_t p);
        
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern size_t lua_rawlen(lua_State luaState, int index);
        */
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_rawset(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_rawseti(lua_State luaState, int index, lua_Integer i);
        
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_setfenv(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_getfenv(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_insert(lua_State luaState, int index);

        /*[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_rawsetp(lua_State luaState, int index, voidptr_t p);
        */

        /* [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
         internal static extern int lua_resetthread(lua_State luaState);*/

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_resume(lua_State luaState, lua_State from, int nargs, out int results);

        /*[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_rotate(lua_State luaState, int index, int n);*/
       
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_remove(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_setallocf(lua_State luaState, lua_Alloc f, voidptr_t ud);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void lua_setfield(lua_State luaState, int index, string key);

       /* [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void lua_setglobal(lua_State luaState, string key);*/
        internal static void lua_setglobal(lua_State luaState, string key)
        {
            lua_setfield(luaState, LUA_GLOBALSINDEX, key);
        }

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_sethook(lua_State luaState, lua_Hook f, int mask, int count);

        /*[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_seti(lua_State luaState, int index, long n);
        */
       /* [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_setiuservalue(lua_State luaState, int index, int n);
        */
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern charptr_t lua_setlocal(lua_State luaState, lua_Debug ar, int n);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_setmetatable(lua_State luaState, int objIndex);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_settable(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_settop(lua_State luaState, int newTop);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern charptr_t lua_setupvalue(lua_State luaState, int funcIndex, int n);

        /*[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_setwarnf(lua_State luaState, lua_WarnFunction warningFunctionPtr, voidptr_t ud);
        */
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_status(lua_State luaState);

        /*[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern size_t lua_stringtonumber(lua_State luaState, string s);
        */
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_toboolean(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_CFunction lua_tocfunction(lua_State luaState, int index);

        /*[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_CFunction lua_toclose(lua_State luaState, int index);
        */

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_Integer lua_tointegerx(lua_State luaState, int index, out int isNum);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern charptr_t lua_tolstring(lua_State luaState, int index, out size_t strLen);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_Number lua_tonumberx(lua_State luaState, int index, out int isNum);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern voidptr_t lua_topointer(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_State lua_tothread(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern voidptr_t lua_touserdata(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_type(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern charptr_t lua_typename(lua_State luaState, int type);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern voidptr_t lua_upvalueid(lua_State luaState, int funcIndex, int n);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_upvaluejoin(lua_State luaState, int funcIndex1, int n1, int funcIndex2, int n2);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_Number lua_version(lua_State luaState);

        /*[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl,CharSet = CharSet.Ansi)]
        internal static extern void lua_warning(lua_State luaState, string msg, int tocont);
        */
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void lua_xmove(lua_State from, lua_State to, int n);

        /*[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_yieldk(lua_State luaState,
            int nresults,
            lua_KContext ctx,
            lua_KFunction k);
            */
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int lua_yield(lua_State luaState,int nresults);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int luaL_argerror(lua_State luaState, int arg, string message);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int luaL_callmeta(lua_State luaState, int obj, string e);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaL_checkany(lua_State luaState, int arg);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_Integer luaL_checkinteger(lua_State luaState, int arg);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern charptr_t luaL_checklstring(lua_State luaState, int arg, out size_t len);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_Number luaL_checknumber(lua_State luaState, int arg);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int luaL_checkoption(lua_State luaState, int arg, string def, string [] list);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void luaL_checkstack(lua_State luaState, int sz, string message);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaL_checktype(lua_State luaState, int arg, int type);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern voidptr_t luaL_checkudata(lua_State luaState, int arg, string tName);

       /* [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void luaL_checkversion_(lua_State luaState, lua_Number ver, size_t sz);
        */
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int luaL_error(lua_State luaState, string message);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaL_execresult(lua_State luaState, int stat);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int luaL_fileresult(lua_State luaState, int stat, string fileName);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int luaL_getmetafield(lua_State luaState, int obj, string e);
        /*
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int luaL_getsubtable(lua_State luaState, int index, string name);
        */
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_Integer luaL_len(lua_State luaState, int index);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int luaL_loadbufferx
            (lua_State luaState,
            byte[] buff,
            size_t sz,
            string name,
            string mode);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int luaL_loadstring
            (lua_State luaState,string s);
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int luaL_loadfilex(lua_State luaState, string name, string mode);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int luaL_newmetatable(lua_State luaState, string name);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_State luaL_newstate();

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaL_openlibs(lua_State luaState);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_Integer luaL_optinteger(lua_State luaState, int arg, lua_Integer d);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern lua_Number luaL_optnumber(lua_State luaState, int arg, lua_Number d);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaL_ref(lua_State luaState, int registryIndex);

        /*[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void luaL_requiref(lua_State luaState, string moduleName, lua_CFunction openFunction, int global);
        */
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaL_setfuncs(lua_State luaState, [In] LuaRegister [] luaReg, int numUp);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void luaL_setmetatable(lua_State luaState, string tName);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern voidptr_t luaL_testudata(lua_State luaState, int arg, string tName);

        /*[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern charptr_t luaL_tolstring(lua_State luaState, int index, out size_t len);*/

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern charptr_t luaL_traceback
           (lua_State luaState,
            lua_State luaState2,
            string message,
            int level);

        /*[DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int luaL_typeerror(lua_State luaState, int arg, string typeName);
        */
        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaL_unref(lua_State luaState, int registryIndex, int reference);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaL_where(lua_State luaState, int level);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaX_setExtra(lua_State luaState, System.IntPtr ptr);

        [DllImport(LuaLibraryName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern System.IntPtr luaX_getExtra(lua_State luaState);
#pragma warning restore IDE1006 // Naming Styles

    }
}
