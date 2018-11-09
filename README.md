# ATESoft_SDK_INSTR-仪表控制管理库
用于记录在实践中通过查询并使用的SCPI指令，核心使用方式是*继承*

## 1. Github更新操作指南，
### 核心步骤是：
- （远端）拉下代码后，（本地）从主分支上创建自己的独立分支比如tangliwen
- （本地）在独立分支进行更新并commit到本地。
- （本地）切回master并检查是否有更新，接着merge自己的分支，这样就把自己更新的内容合并到主干上了。
- （远端）最后将master push即可
### Git指令收集
由于我们使用Github Desktop可以在图形化界面里完成很多日常的常规操作，但是有一些高级指令是需要在shell执行的，以下即是这些手敲指令
- git log日志记录
- git branch -d <branch_name> 删除分支
- git branch <branch_name> <hash_val>
- git reflog 查找被删除分支的散列值，然后通过上面方法回复分支
- git reset --hard 139dcfaa558e3276b30b6b2e5cbbb9c00bbdca96 倒回之前版本**不要用**
