using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class Test
    {

    }

    public class A
    { }

}

public class A
{

}

public class B
{

}

public class C
{

}

public class IL2CPP_Info
{
    public List<A> list;
    public List<B> list2;
    public List<C> list3;

    public Dictionary<int, string> dic = new Dictionary<int, string>();

    public void Test<T>(T info)
    {

    }

    public static void Test()
    {
        IL2CPP_Info info = new IL2CPP_Info();
        info.Test<int>(1);
        info.Test<float>(1);
        info.Test<bool>(true);
    }

}



public class Lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #region ֪ʶ��һ ���� ��װUnity IL2CPP�������
        //��Unityhub������ IL2CPP�����ع���
        #endregion

        #region ֪ʶ��� ���� IL2CPP������ڵ����⡪�����Ͳü�
        //IL2CPP�ڴ��ʱ���Զ���Unity���̵�DLL���вü�����������û�����õ������Ͳü�����
        //�Դﵽ��С��������ĳߴ��Ŀ�ġ�
        //Ȼ����ʵ��ʹ�ù����У��ܶ������п��ܻᱻ������õ���
        //�������ʱ�׳��Ҳ���ĳ�����͵��쳣��
        //�ر���ͨ������ȷ�ʽ�ڱ���ʱ�޷���֪�ĺ������ã�������ʱ�����п�����������

        //���������
        //1.IL2CPP����ģʽʱ����PlayerSetting->Other Setting->Managed Stripping Level(�������)����ΪLow
        // Disable:Monoģʽ�²�������Ϊ��ɾ���κδ���
        // Low:Ĭ�ϵͼ��𣬱��ص�ɾ�����룬ɾ��������޷����ʵĴ��룬ͬʱҲ���̶ȼ��ٰ���ʵ��ʹ�õĴ���Ŀ�����
        // Medium:�еȼ��𣬲���ͼ�����������Ҳ����ﵽ�߼���ļ���
        // Hight:�߼��𣬾����ܶ��ɾ���޷����ʵĴ��룬�����Ż��ߴ��С�����ѡ���ģʽһ����Ҫ���link.xmlʹ��

        //2.ͨ��Unity�ṩ��link.xml��ʽ������Unity���棬��Щ�����ǲ��ܹ������õ���
        //  ��Unity���̵�AssetsĿ¼�У������κ���Ŀ¼�У�����һ����link.xml��XML�ļ�
        #endregion

        #region ֪ʶ���� ���� IL2CPP������ڵ����⡪����������
        //�����Ͻڿ��ᵽ��IL2CPP��Mono���������� ����������ʱ��̬���ɴ��������
        //����˵ ������ص����ݣ�������ڴ������ǰû�а�֮����Ҫʹ�õķ���������ʾʹ��һ��
        //��ô֮�����ʹ��û�б���������ͣ��ͻ�����Ҳ������͵ı���

        //������List<A>��List<B>��A��B�������Զ�����࣬
        //���ܱ����ڴ�������ʾ�ĵ��ù���IL2CPP���ܱ���List<A>��List<B>�������͡�
        //������ȸ���ʱ���ǵ���List<C>��������֮ǰ��û���ڴ�������ʾ���ù���
        //��ô��ʱ�ͻ���ֱ�������⡣��Ҫ������ΪJIT��AOT��������ģʽ�Ĳ�ͬ��ɵ�
        List<A> list = new List<A>();
        List<B> list2 = new List<B>();

        //���������
        //�����ࣺ����һ���࣬Ȼ���������������һЩpublic�ķ��������
        //���ͷ��������дһ����̬�������ڽ�������ͷ��������е���һ�¡������̬�������豻����
        //��������Ŀ����ʵ������Ԥ�Ա���֮ǰ��IL2CPP֪��������Ҫʹ���������
        #endregion

        #region �ܽ�
        //��������Ŀǰ����������Ŀ
        //��������ʹ��IL2CPP�ű�����ģʽ�����д��
        //��Ҫԭ������Ϊ����Ч�����Mono�ϸߣ�ͬʱ�������Դ��ü����ܣ����Ĵ�СҲ��СһЩ
        //��������ڲ���ʱ���� �����޷�ʶ�������
        //��Ҫ�õ�������ڿ�ѧϰ��֪ʶ���������Щ����
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
