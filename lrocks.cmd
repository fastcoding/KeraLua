@setlocal
@set rootdir=%~d0%~p0
@set luarocks=C:\tools\lua-rsrc\LuaJIT\dist\share\luarocks\luarocks.bat
@set luadir=%rootdir%external\luajit\install-x64
@set lua=%luadir%bin\lua.exe
%luarocks%  --lua-dir %luadir% --lua-version 5.1 --tree %luadir% LUALIB=lua.lib LUA_LIBRARY=lua.lib LUA_LIBDIR=%luadir%\lib %* 
