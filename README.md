# 🚀 TextClear - 极简纯净文本净化器

![GitHub Release](https://img.shields.io/github/v/release/Lucky-Hope528/TextClear)
![GitHub Stars](https://img.shields.io/github/stars/Lucky-Hope528/TextClear)
![Platform](https://img.shields.io/badge/Platform-Windows_10%2B-blue)
![License](https://img.shields.io/github/license/Lucky-Hope528/TextClear)

**TextClear** 是一款基于 **WinUI 3** 和 **.NET 8** 开发的高颜值桌面工具。它专为消除剪贴板格式杂质而生，无论是网页源码、PDF 乱码还是带格式的文档，都能一键还原为极致纯净的文本。

---

## ✨ 核心功能

### 🛡️ 深度净化 (Deep Purify) - **New v1.1.0**
这是本项目最强大的功能，专为处理杂乱源码和网页抓取内容设计：
- **杀掉 HTML 标签**：自动剔除所有 HTML/XML 标签（如 `<div>`, `<span>`, `<a>` 等）。
- **转义符还原**：自动将网页转义字符（如 `&nbsp;`, `&lt;`, `&quot;`）解码为肉眼可读的正常符号。
- **极致空间压缩**：将所有混乱的制表符、多余空格和换行符一键打平，输出完美的连续长段落。

### 📝 基础处理
- **首尾去空**：自动修剪文本前后的空白。
- **合并空行**：智能压缩冗余的换行符，保持排版紧凑。

### 🎨 现代交互
- **云母视觉 (Mica)**：完美适配 Windows 11 的原生设计语言，透亮美观。
- **开关联动**：智能互斥逻辑，开启深度净化时自动简化操作，防止逻辑冲突。
- **一键复制**：净化完成后自动将结果送入剪贴板，秒变生产力。

---

## 🛠️ 技术架构

- **UI 框架**：WinUI 3 (Windows App SDK)
- **核心引擎**：.NET 8
- **部署模式**：独立部署 (Self-contained, Unpackaged)，下载即用。
- **打包工具**：Inno Setup (支持安装路径检测与非空拦截)

---

## 📥 快速开始

1. 前往本仓库的 [Releases](https://github.com/Lucky-Hope528/TextClear/releases) 页面。
2. 下载最新的 `TextClearSetup.exe`。
3. 双击安装程序，按照引导完成安装。
4. 运行 `TextClear`，粘贴你的文本并点击“全量净化并复制”。

---

## 📸 软件预览

*(建议在此处上传一张你的软件运行截图，能极大增加项目的吸引力！)*
<img width="1905" height="1111" alt="image" src="https://github.com/user-attachments/assets/10685bf6-c34f-4039-86a3-46017c0f52a2" />

---

## 📜 开源协议

本项目采用 **MIT License**。你可以自由地使用、修改和分发。

---

**如果你觉得 TextClear 帮到了你，请点一个 ⭐ Star，这是对开发者最大的鼓励！**
