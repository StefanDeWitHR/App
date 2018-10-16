package md5138b61949e3f9b08b3a2cf4ee6f65b18;


public class ShareRenderer
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("App.Droid.ShareRenderer, App.Android", ShareRenderer.class, __md_methods);
	}


	public ShareRenderer ()
	{
		super ();
		if (getClass () == ShareRenderer.class)
			mono.android.TypeManager.Activate ("App.Droid.ShareRenderer, App.Android", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
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
