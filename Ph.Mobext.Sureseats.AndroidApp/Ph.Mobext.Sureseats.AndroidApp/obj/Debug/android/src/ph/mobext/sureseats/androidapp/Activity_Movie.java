package ph.mobext.sureseats.androidapp;


public class Activity_Movie
	extends ph.mobext.sureseats.androidapp.MainActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onBackPressed:()V:GetOnBackPressedHandler\n" +
			"";
		mono.android.Runtime.register ("Ph.Mobext.Sureseats.AndroidApp.Activity_Movie, Ph.Mobext.Sureseats.AndroidApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Activity_Movie.class, __md_methods);
	}


	public Activity_Movie () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Activity_Movie.class)
			mono.android.TypeManager.Activate ("Ph.Mobext.Sureseats.AndroidApp.Activity_Movie, Ph.Mobext.Sureseats.AndroidApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onBackPressed ()
	{
		n_onBackPressed ();
	}

	private native void n_onBackPressed ();

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
