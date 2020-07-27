using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using KeraLua;

namespace mytest
{
    class Program
    {
        public static int Func(IntPtr p)
        {
            var state = Lua.FromIntPtr(p);
            long param1 = state.CheckInteger(1);
            long param2 = state.CheckInteger(2);
            Trace.WriteLine("callback with " + param1 + "," + param2);
            state.PushInteger(param1 + param2);
            return 1;
        }
        public static LuaFunction func_print = print;
        static int print(IntPtr p)
        {
            var state = Lua.FromIntPtr(p);
            int n = state.GetTop();  /* number of arguments */
            int i;
            for (i = 1; i <= n; i++)
            {
                LuaType type = state.Type(i);
                switch (type)
                {

                    case LuaType.Nil:
                        Trace.Write("nil");
                        break;
                    case LuaType.String:
                        string s = state.ToString(i, false);
                        Trace.Write(s);                        
                        break;
                    case LuaType.Number:
                        double number = state.ToNumber(i);
                        Trace.Write(number);
                        break;
                }
            }
            Trace.WriteLine("\n");
            return 0;
        }
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Lua lua = new Lua();
            
            using (var lua2 = new Lua())
            {
                lua2.PushNumber(3);
                lua2.PushInteger(4);

                int currentTop = lua2.GetTop();

                string four = lua2.ToString(-1);

                int newTop = lua2.GetTop();

                Trace.WriteLine("4" +" "+four+  " #1.1");
                Trace.WriteLine(currentTop+" "+newTop + " #1.2");
                lua2.DoString("function f() end");
                LuaType type = lua2.GetGlobal("f");
                Trace.WriteLine("f:" + type);
            }
                
            
            lua.Register("func1", Func);

            string script = @"function yielder() 
                                a=1; 
                                coroutine.yield();
                                a = func1(3,2);
                                a = func1(4,2);
                                coroutine.yield();
                                a=2;
                                coroutine.yield();
                             end
                             co_routine = coroutine.create(yielder);
                             while coroutine.resume(co_routine) do end;";
            lua.DoString(script);
            lua.DoString(script);

            lua.GetGlobal("a");
            long a = lua.ToInteger(-1);
            Trace.WriteLine("a is " + a);
            lua.DoString("hello=0");
            if (lua.LoadString("hello = 1") == LuaStatus.OK)
            {
                string result = lua.GetUpValue(-1, 1);//not work in luajit or 5.1
                Trace.WriteLine("result is " + result);
            }
            
            
            lua.Register("myprint", func_print);
            if (lua.LoadString("args=...;print('hello,',args);myprint('hello',args)") == LuaStatus.OK)
            {
                lua.PushString("hanxi");
                lua.Call(1, 0);
            }
            
            Console.ReadKey();
            lua.Close();
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
