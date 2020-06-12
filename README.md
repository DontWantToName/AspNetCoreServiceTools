# AspNetCoreServiceTools
Asp.net Core 服务注册
早上刚在博客园看了个大佬的帖子 受到了启发 写了个netcore的有关于服务注册的工具

大佬可以关闭网页了 新手随便写写

你是否因为注册服务过多感到代码冗余难受吗(不是)
快来使用我这个公共类叭

使用要求：
要有一个实现接口的类库项目；
还要再这个文件夹下建三个文件夹对应服务注册生命周期(建文件夹是为了统一命名空间)；
调用的时候要传项目名和三个生命周期的名称；
    
使用案例：

asp.net core webapi 项目 demo  
类库 接口项目 Iservice  
类库 实现接口项目 service 

service下有三个文件夹 Scoped、Singleton、Transient (类的命名空间都是service.文件夹名称)
demo项目startup文件里的ConfigureServices调用：
    services.RegisterServices("service","Scoped","Singleton","Transient");
