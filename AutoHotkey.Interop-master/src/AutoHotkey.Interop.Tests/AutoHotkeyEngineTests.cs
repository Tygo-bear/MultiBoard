﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AutoHotkey.Interop;

namespace AutoHotkey.Interop.Tests
{
    public class AutoHotkeyEngineTests
    {
        AutoHotkeyEngine ahk = AutoHotkeyEngine.Instance;

        [Fact]
        public void can_set_and_get_variable() {
            ahk.SetVar("var1", "awesome");
            string var1Value = ahk.GetVar("var1");

            Assert.Equal("awesome", var1Value);
        }

        [Fact]
        public void can_set_variable_with_raw_code() {

            ahk.ExecRaw("var2:=\"great\"");
            string var2Value = ahk.GetVar("var2");

            Assert.Equal("great", var2Value);
        }

        [Fact]
        public void can_load_and_execute_file_with_function() {
            ahk.LoadFile("functions.ahk");
            bool helloFunctionExists = ahk.FunctionExists("hello_message");
            Assert.True(helloFunctionExists);

            var result = ahk.ExecFunction("hello_message", "John");
            Assert.Equal("Hello, John", result);
        }
        

        [Fact]
        public void resetting_engine_kills_variables() {
            ahk.SetVar("var3", "12345");
            ahk.Reset();

            string var_after_termination = ahk.GetVar("var3");
            Assert.Empty(var_after_termination);
        }

        [Fact] 
        public void can_change_variable_after_reset() {
            ahk.SetVar("var4", "54321");
            ahk.Reset();
            ahk.SetVar("var4", "55555");

            string var4Value = ahk.GetVar("var4");
            Assert.Equal("55555", var4Value);
        }
        
        [Fact]
        public void can_create_ahk_function_and_return_value_with_raw_code() {
            ahk.ExecRaw("calc(n1, n2) {\r\nreturn n1 + n2 \r\n}");
            string returnValue = ahk.ExecFunction("calc", "1", "2");

            Assert.Equal("3", returnValue);
        }

        [Fact]
        public void can_return_function_result_with_eval() {
            
            //create the function
            ahk.ExecRaw("TestFunctionForEval() {\r\n return \"It Works!\" \r\n}");
            
            //test the eval
            string results = ahk.Eval("TestFunctionForEval()");

            Assert.Equal("It Works!", results);
        }

        [Fact]
        public void can_evaluate_expressions() {
            Assert.Equal("450", ahk.Eval("100+200*2-50"));
            Assert.Equal("230", ahk.Eval("20*10+30"));
            Assert.Equal("210", ahk.Eval("10*20+5*2"));
            Assert.Equal("50", ahk.Eval("100 - 50"));

            //Assert.Equal("2", ahk.Eval("10 / 5")); 
            //TODO: there seems to be a problem with division with ahkdll
        }

        [Fact]
        public void can_auto_exec_in_file() {
            //loads a file and allows the autoexec section to run
            //(sets a global variable)
            ahk.LoadFile("script_exec.ahk");
            string script_var = ahk.GetVar("script_exec_var");
            Assert.Equal("jack skellington", script_var);

            //run function inside this file to change global variable
            //(changes the perviously defined global variable)
            ahk.ExecFunction("script_exec_var_change");
            script_var = ahk.GetVar("script_exec_var");
            Assert.Equal("zero", script_var);
        }

        [Fact]
        public void loading_pipes_module_executes_function() {
            bool handlerWasCalled = false;

            var handler = new Func<string, string>(ahkMessage => {
                handlerWasCalled = true;
                System.Threading.Thread.Sleep(1000);
                return "OK";
            });

            ahk.InitalizePipesModule(handler);
            ahk.ExecRaw("serverResult := SendPipeMessage(\"testing\")");
            Assert.True(handlerWasCalled);
        }
    }
}
