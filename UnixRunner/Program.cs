// See https://aka.ms/new-console-template for more information

using Starlight.API;
using Starlight.Loader;

var loader = new Loader();
loader.AddAssembly("Starlight.Core.dll");
loader.AddAssembly("Starlight.Renderer.dll");
loader.Load();

var engine = IEngine.Create();
engine.Start();