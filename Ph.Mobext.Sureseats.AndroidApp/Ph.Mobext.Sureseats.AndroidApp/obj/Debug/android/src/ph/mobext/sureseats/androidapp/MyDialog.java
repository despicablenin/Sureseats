package ph.mobext.sureseats.androidapp;


public class MyDialog
	extends ph.mobext.sureseats.androidapp.BaseFragmentActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Ph.Mobext.Sureseats.AndroidApp.MyDialog, Ph.Mobext.Sureseats.AndroidApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyDialog.class, __md_methods);
	}


	public MyDialog () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyDialog.class)
			mono.android.TypeManager.Activate ("Ph.Mobext.Sureseats.AndroidApp.MyDialog, Ph.Mobext.Sureseats.AndroidApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
