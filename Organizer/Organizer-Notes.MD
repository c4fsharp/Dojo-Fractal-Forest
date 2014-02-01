#General

This is a fairly straightforward Dojo, which doesn't really require upfront explanation. It should be enough to tell people that the goal is to create nice fractal trees, using recursion, starting from the script "Script.fsx" included in the Dojo folder. However, showing how a [simple fractal tree][simple-tree], or a [more interesting one][kidney-tree] looks like might help get people excited :)  

The script is self-explanatory. When people run it, it should launch a window with a pretty sad-looking tree. **The script has been tested on Windows and Mono; it works, but the Mono version is quite slow**.

The hardest part of the dojo is to get the recursion working. A basic solution is provided in the Organizer folder, but lots of approaches are possible. A good path forward is to first try to get a simple symmetrical tree working, with every branch forking into 2 shorter branches. Once that is done, a lot of directions are possible:  
* experiment to create nice-looking figures: vary angles, length, width, number of branches per node, introduce randomness, color...
* improve the code: optimize for speed, separate the generation of branches from the rendering, make the UI code asynchronous and non-blocking, [use FunScript to render in JavasScript][funscript]...  

**Encourage people to Tweet or share images of their work, using the hashtag #fsharp!**  

If the group is not too large, this is a good dojo to have a show-and-tell at the end: reserve 30 minutes at the end of the session, and have people show the result of their work, as well as their code. Comparing what directions people took, and what problems they had, is often quite interesting!  

[simple-tree]: https://raw.github.com/c4fsharp/Dojo-Fractal-Forest/master/Assets/tall-tree.jpg "Fractal tree"
[kidney-tree]: https://raw.github.com/c4fsharp/Dojo-Fractal-Forest/master/Assets/kidney-tree.jpg "Kidney-shaped fractal tree"
[funscript]:
http://lasandell.github.io/FractalFun/ "Fractal Tree with FunScript"