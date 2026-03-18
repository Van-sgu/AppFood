package crc64ed1888fb4925e3b7;


public class AuthenticationAgentActivity_CoreWebViewClient
	extends android.webkit.WebViewClient
	implements
		mono.android.IGCUserPeer
{

	public AuthenticationAgentActivity_CoreWebViewClient ()
	{
		super ();
		if (getClass () == AuthenticationAgentActivity_CoreWebViewClient.class) {
			mono.android.TypeManager.Activate ("Microsoft.Identity.Client.Platforms.Android.EmbeddedWebview.AuthenticationAgentActivity+CoreWebViewClient, Microsoft.Identity.Client", "", this, new java.lang.Object[] {  });
		}
	}

	public AuthenticationAgentActivity_CoreWebViewClient (java.lang.String p0, android.app.Activity p1)
	{
		super ();
		if (getClass () == AuthenticationAgentActivity_CoreWebViewClient.class) {
			mono.android.TypeManager.Activate ("Microsoft.Identity.Client.Platforms.Android.EmbeddedWebview.AuthenticationAgentActivity+CoreWebViewClient, Microsoft.Identity.Client", "System.String, System.Private.CoreLib:Android.App.Activity, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}

	public void onLoadResource (android.webkit.WebView p0, java.lang.String p1)
	{
		n_onLoadResource (p0, p1);
	}

	private native void n_onLoadResource (android.webkit.WebView p0, java.lang.String p1);

	public boolean shouldOverrideUrlLoading (android.webkit.WebView p0, java.lang.String p1)
	{
		return n_shouldOverrideUrlLoading (p0, p1);
	}

	private native boolean n_shouldOverrideUrlLoading (android.webkit.WebView p0, java.lang.String p1);

	public void onPageFinished (android.webkit.WebView p0, java.lang.String p1)
	{
		n_onPageFinished (p0, p1);
	}

	private native void n_onPageFinished (android.webkit.WebView p0, java.lang.String p1);

	public void onPageStarted (android.webkit.WebView p0, java.lang.String p1, android.graphics.Bitmap p2)
	{
		n_onPageStarted (p0, p1, p2);
	}

	private native void n_onPageStarted (android.webkit.WebView p0, java.lang.String p1, android.graphics.Bitmap p2);

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
