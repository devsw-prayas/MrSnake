using Python.Runtime;
using System;
using System.Threading.Tasks;

namespace MrSnake
{
    public class Frontend
    {
        private dynamic backend { get; set; }
        private dynamic obj { get; set; }
        private bool isPaused { get; set; }
        private bool isKilled { get; set; }
        private dynamic humanCode { get; set; }
        private dynamic game { get; }

        public Frontend()
        {
            string pythonDll = @"C:\Users\malli\AppData\Local\Programs\Python\Python39\python39.dll";
            Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", pythonDll);

            PythonEngine.Initialize();
            PythonEngine.BeginAllowThreads();
            isPaused = false;
            using (Py.GIL())
            {
                backend = Py.Import("backend.backendAI");
                obj = backend.Backend();
            }
        }

        public void start()
        {
            isKilled = false;
            train();
        }

        public async void train()
        {
            while (!isKilled)
            {
                if (isPaused)
                {
                    await Task.Delay(1000);
                    continue;
                }
                using (Py.GIL())
                {
                    obj.train();
                }
            }
        }

        public void pause()
        {
            isPaused = true;
        }

        public void resume()
        {
            isPaused = false;
        }

        public void kill()
        {
            isKilled = true;
        }
    }
}