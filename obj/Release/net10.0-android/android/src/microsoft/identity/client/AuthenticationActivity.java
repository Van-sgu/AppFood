package microsoft.identity.client;


public class AuthenticationActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{

	public AuthenticationActivity ()
	{
		super ();
		if (getClass () == AuthenticationActivity.class) {
			mono.android.TypeManager.Activate ("Microsoft.Identity.Client.Platforms.Android.SystemWebview.AuthenticationActivity, Microsoft.Identity.Client", "", this, new java.lang.Object[] {  });
		}
	}

	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	public void onNewIntent (android.content.Intent p0)
	{
		n_onNewIntent (p0);
	}

	private native void n_onNewIntent (android.content.Intent p0);

	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();

	public void onSaveInstanceState (android.os.Bundle p0)
	{
		n_onSaveInstanceState (p0);
	}

	private native void n_onSaveInstanceState (android.os.Bundle p0);

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
