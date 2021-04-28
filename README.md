# LabMerge

LabMerge は、音声合成ソフトなどから出力されるタイミング情報のテキスト出力である、
lab ファイルに書かれた情報を統合して一つにまとめるツールです。

特定のキャラクターに歌わせる際に、ボーカルパートとコーラスパートの lab ファイルをまとめて一つにするといった用途を想定しています。

## 基本的な使い方

統合したい lab ファイル複数を ctrl を押しながら選択し、 LabMerge.exe にドラッグ&ドロップします。
統合が完了したら、 `<最初に選択した lab ファイル>-merge.lab` というファイルが生成されます。
生成された lab ファイルが統合後のファイルとなっているため、それを lab ファイルを必要とするツールなどで使用してください。

なお、統合時に生成しようとしたファイルがすでに存在していた場合、 "<最初に選択した lab ファイル>-merge(<数字>).lab" といった形で上書きせずに新しいファイルを生成します。

また、 sample フォルダにサンプル用の lab ファイルを 2 つ用意しています。
すぐに使用できる lab ファイルがない場合は、これら 2 つのファイルを選択して LabMerge.exe にドラッグ&ドロップすることで使い方を確かめられます。

## より詳しい使い方

コマンドラインから LabMerge を実行することで、出力ファイルパスの指定も可能です。
出力ファイルパスにすでにファイルが存在している場合、そのファイルは上書きされます。

```
LabMerge.exe -o <出力ファイルパス> <入力ファイルパス1> <入力ファイルパス2> <入力ファイルパス3>...
```

## 使用した OSS

* [CommandLineParser](https://github.com/commandlineparser/commandline)
* [CsvHelper](https://github.com/JoshClose/CsvHelper)

## ライセンス

LabMerge は MIT ライセンスの元配布されます。
詳細は、 [ライセンスファイル](LICENSE) を参照してください。

また、内部で使用している OSS についてのライセンスについては、以下の場所を参照してください。
* [CommandLineParser](third-party/CommandLineParser/License.md)
* [CsvHelper](third-party/CsvHelper/LICENSE.txt)

## その他
質問や不具合、相談、要望などありましたら、下記のアカウントまでご連絡ください。
twitter: @tanoshimi2000s

## 参考

* [Cevio 公式サイト](http://cevio.jp/)
* [KotonoSync 紹介サイト](http://ch.nicovideo.jp/suzumf/blomaga/ar1073288)
