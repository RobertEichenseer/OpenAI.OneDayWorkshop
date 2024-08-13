# OpenAI.Workshop

## Self paced learning & class room training

The Azure OpenAI one-day workshop can be delivered by a trainer in a classroom setup, providing interactive and hands-on learning experiences. Additionally, it can be used as a self-paced learning resource, supported by [multiple video files](./Media/mp4) in the repository that explain fundamental concepts, ensuring comprehensive understanding and flexibility for all learners.

### Introduction Tutorials

This training comes with introduction tutorials. The videos are part of the repository to support consumption in bandwidth limited environments and for direct consumption in dev environments like VS Code without context switching.

| Chapter | Content | Video Link |
| ------- | ------- | ------- |
| Introduction| Explanation of fundamental concepts.| [Introduction](./Media/mp4/01_Intro.mp4)|
| Setup| Azure Setup. Create all necessary Azure instances to run the samples provided in the workbooks| [Setup](./Media/mp4/02_Setup.mp4)|
| RAG| Retrieval Augmented Generation. Multiple notebooks and technologies to support effective RAG development| [RAG](./Media/mp4/03_RAG.mp4) |
| Tools | Function calling or Tools in the context of LLMs| [Tools](./Media/mp4/04_Tools.mp4) |
| Assistants API| How to use the OpenAI Assistants API | [Assistants](./Media/mp4/05_Assistants.mp4) |
| Semantic Kernel | Open Source Tool to develop AI applications | [SemanticKernel](./Media/mp4/06_SemanticKernel.mp4) |
| Closing | Videos have been created using Azure OpenAI and Azure AI Speech Custom Neural Voice | [Closing](./Media/mp4/07_Closing.mp4) |

## SDK

This repository uses the [.NET SDK version Beta 2](https://www.nuget.org/packages/Azure.AI.OpenAI/2.0.0-beta.2). If you're looking for Beta 1 samples, you can find them [here](https://github.com/RobertEichenseer/OpenAI.OneDayWorkshop/tree/NET-SDK-Beta-1).

## Pre-Requisites

The training comes with a [devcontainer.json](./.devcontainer/devcontainer.json) which allows executing all samples in GitHub codespaces or a local development container.

If you prefer local execution bBe sure to have the following pre-requisites installed:

### Development Environment

- [VSCode](https://code.visualstudio.com/download)
- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-windows?tabs=winget)
- [Git](https://git-scm.com)
- [Powershell](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-windows?view=powershell-7.4)

### VSCode Extensions

- [c#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- [Polyglot NB](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.dotnet-interactive-vscode)
- [Azure CLI](https://marketplace.visualstudio.com/items?itemName=ms-vscode.azurecli)
- [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client)

### Azure OpenAI is a Limited Access service, and access and use is subject to eligibility criteria determined by Microsoft.

[Product Terms & Code of conduct](https://learn.microsoft.com/en-us/legal/cognitive-services/openai/limited-access)

## Agenda

***09:00 - 17:00***

| Time | Topic | Content |
|------|-------|---------|
|09:00 - 10:30 | **Welcome** and overview | An [introduction](./00_IntroWorkshop/OpenAI-Workshop.pdf) of Azure Open AI for .net developer. |
|10:30 - 11:00 | **Intro** Create Environment | [Portal](https://portal.azure.com) or [CLI](./01_CreateEnvironment/01_Environment.ipynb)  |
|11:00 - 11:30 | **RAG** Completion | [Chat Completion HTTP](./02_RAG/02_01_ChatCompletion/01_ChatCompletionText_REST.ipynb) or [Chat Completion SDK](./02_RAG/02_01_ChatCompletion) and [Chat Completion - Image insights](./02_RAG/02_01_ChatCompletion/03_ImageCompletion.ipynb) and [Chat Completion - Image generation](./02_RAG/02_01_ChatCompletion/04_CreateImageCompletion.ipynb) |
|11:30 - 12:30 | **RAG** Embeddings | [Text Embeddings](./02_RAG/02_02_Embedding/01_TextEmbeddings.ipynb) or [Image Embeddings](./02_RAG/02_02_Embedding/02_ImageEmbeddings.ipynb) and [Cosine Similarity](./02_RAG/02_02_Embedding/03_CosineSimilarity.ipynb) |
|12:30 - 13:00 |Break | |
|13:00 - 13:30 | **RAG** Vector DB | [AI Search](./02_RAG/02_03_VectorDB/01_AISearch.ipynb) |
|13:30 - 14:30 | **Function Calling** OpenAI |[Tools SDK](./03_FunctionCalling/01_OpenAI/01_Tools.ipynb) |
|14:30 - 15:00 |Break | |
|15:00 - 16:00 | **Agent Processing** Assistants API | [Simple Run](./04_Agent/01_Assistants/01_CreateRun.ipynb) |
|16:00 - 16:30 | **Tooling** Smeantic Kernel | [Plugins](./05_Tooling/01_SemanticKernel/01_Plugin.ipynb) and [Semantic Memory](./05_Tooling/01_SemanticKernel/02_SemanticMemory.ipynb) and [Function Calling](./05_Tooling/01_SemanticKernel/03_Tools.ipynb) |
|16:30 - 17:00 | Wrap Up | Questions / Knowledge Check |
