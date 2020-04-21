# QMCTrans
QQ音乐解码程序，
针对加密的qmcflac,qmc0,qmc3文件进行解密，用C#重写了。带GUI界面。
仅供交流学习使用。

参考： https://github.com/MegrezZhu/qmcdump

2020/04/21 Update:
添加对mflac文件的支持,修复小bug。
参考：https://github.com/ix64/unlock-music/wiki 对mflac文件的说明。

下面给出几点对Key，也就是掩码的说明：
*  Key的真实有效位数只有里面44个Byte
*  Key有周期性，周期为128Byte
*  Key有对称性，满足对称关系：Key\[i\] = Key\[128-i\]  i>=1

文件尾部是一个结构体，包含有Key的信息，但是现在无法解密。
结构体如下：
```
struct KeyINFO{
    string Base64EncryptedKeyInfo;
    Uint32 sizeofBase64EncryptedKeyInfo;
}
```
