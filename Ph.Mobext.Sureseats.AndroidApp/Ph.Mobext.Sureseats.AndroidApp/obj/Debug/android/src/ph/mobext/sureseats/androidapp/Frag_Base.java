package ph.mobext.sureseats.androidapp;


public class Frag_Base
	extends android.support.v4.app.Fragment
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onLowMemory:()V:GetOnLowMemoryHandler\n" +
			"";
		mono.android.Runtime.register ("Ph.Mobext.Sureseats.AndroidApp.Frag_Base, Ph.Mobext.Sureseats.AndroidApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Frag_Base.class, __md_methods);
	}


	public Frag_Base () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Frag_Base.class)
			mono.android.TypeManager.Activate ("Ph.Mobext.Sureseats.AndroidApp.Frag_Base, Ph.Mobext.Sureseats.AndroidApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onLowMemory ()
	{
		n_onLowMemory ();
	}

	private native void n_onLowMemory ();

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
