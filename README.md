This project was made by students of Fontys hogenscholen for Omroep Flevoland.

To run this repository Flowise and Ollama are required.

Flowise is a low code tool that can be installed through the [Node.jsx64 package manager](https://nodejs.org/en/download/prebuilt-installer) or npm for short.
1. The install command is `npm i -g flowise`.
2. To start Flowise use the next command `npx flowise start` and got to this line [http://localhost:3000](http://localhost:3000)
3. Then The chatflow export in the forlder Flowise in this repository can be used to get a chatflow compatible with the ASP website. You can inport it into a flow after creating a flow. 
4. With the chatflow imported, the File path for th Fais module needs to be properly filed in together with the URL's for Ollama.

To install Ollama with the right moduals you can follow thise steps:
1. [Download Ollama](https://ollama.com/download) and run it once, it should open a powershell or Command promt window.
2. once you have the powershell or Command promt window you can check [http://localhost:11434/][http://localhost:11434/] and it should say "Ollama is running". if you don't see this Ollama isn't running and can be started by looking for Ollama on your system.
3. if Ollama is running use the next two commands in the Powershell or Command Promt window to download the necessary Moduals 
- `ollama pull llama3`
- `ollama pull mxbai-embed-large`
4. if both are downloaded you can try and run `ollama run llama3`. It should allow you to ask some question. Note that this model is currently not connected to the internet.
