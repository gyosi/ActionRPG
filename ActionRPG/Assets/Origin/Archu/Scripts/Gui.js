#pragma strict

var weapon : Transform;
var halo : Transform;
var wings : Transform;
var wingsMesh : Transform;

function Start () {
	GetComponent.<Animation>().CrossFade("Idle"); 
	wings.GetComponent.<Animation>().CrossFade("Idle");  
}

function Update () {

}

function OnGUI () {
	//窈?ㅊ閭?솳
	if(GUILayout.Button("Show/Hide Weapon")){
		if(weapon.GetComponent.<Renderer>().enabled == true)
			weapon.GetComponent.<Renderer>().enabled = false;
		else
			weapon.GetComponent.<Renderer>().enabled = true;
    }
	//窈?ㅊ?됬뮥
	if(GUI.Button(Rect(140, 0, 120, 20), "Show/Hide Halo")){
		if(halo.GetComponent.<Renderer>().enabled == true)
			halo.GetComponent.<Renderer>().enabled = false;
		else
			halo.GetComponent.<Renderer>().enabled = true;
    }
	//窈?ㅊ玲낁?
	if(GUI.Button(Rect(280, 0, 120, 20), "Show/Hide wings")){
		if(wingsMesh.GetComponent.<Renderer>().enabled == true)
			wingsMesh.GetComponent.<Renderer>().enabled = false;
		else
			wingsMesh.GetComponent.<Renderer>().enabled = true; 
    }
	//?뺜퐳
	if(GUILayout.Button("Idle")){
        GetComponent.<Animation>().CrossFade("Idle"); 
        wings.GetComponent.<Animation>().CrossFade("Idle");
    }
	if(GUILayout.Button("Idle2")){
        GetComponent.<Animation>().CrossFade("Idle2");
        wings.GetComponent.<Animation>().CrossFade("Idle2");
    }
	if(GUILayout.Button("Walk")){
		weapon.GetComponent.<Renderer>().enabled = true;
        GetComponent.<Animation>().CrossFade("Walk"); 
        wings.GetComponent.<Animation>().CrossFade("Walk");
    }
	if(GUILayout.Button("Walk2")){
		weapon.GetComponent.<Renderer>().enabled = false;
        GetComponent.<Animation>().CrossFade("Walk2"); 
        wings.GetComponent.<Animation>().CrossFade("Walk2");
    }
	if(GUILayout.Button("Run")){
		weapon.GetComponent.<Renderer>().enabled = true;
        GetComponent.<Animation>().CrossFade("Run"); 
        wings.GetComponent.<Animation>().CrossFade("Run");
    }
	if(GUILayout.Button("Run2")){
		weapon.GetComponent.<Renderer>().enabled = false;
        GetComponent.<Animation>().CrossFade("Run2"); 
        wings.GetComponent.<Animation>().CrossFade("Run2");
    }
	if(GUILayout.Button("Jump")){
		weapon.GetComponent.<Renderer>().enabled = true;
        GetComponent.<Animation>().CrossFade("Jump"); 
        wings.GetComponent.<Animation>().CrossFade("Jump");
    }
	if(GUILayout.Button("Jump2")){
		weapon.GetComponent.<Renderer>().enabled = false;
        GetComponent.<Animation>().CrossFade("Jump2"); 
        wings.GetComponent.<Animation>().CrossFade("Jump2");
    }
	if(GUILayout.Button("Attack1")){
        GetComponent.<Animation>().CrossFade("Attack1");
        wings.GetComponent.<Animation>().CrossFade("Attack1");
    }
	if(GUILayout.Button("Attack2")){
        GetComponent.<Animation>().CrossFade("Attack2"); 
        wings.GetComponent.<Animation>().CrossFade("Attack2");
    }
	if(GUILayout.Button("Attack3-1")){
        GetComponent.<Animation>().CrossFade("Attack3-1"); 
        wings.GetComponent.<Animation>().CrossFade("Attack3-1");
    }
	if(GUILayout.Button("Attack3-2")){
        GetComponent.<Animation>().CrossFade("Attack3-2"); 
        wings.GetComponent.<Animation>().CrossFade("Attack3-2");
    }
	if(GUILayout.Button("Attack3-3")){
        GetComponent.<Animation>().CrossFade("Attack3-3"); 
        wings.GetComponent.<Animation>().CrossFade("Attack3-3");
    }
	if(GUILayout.Button("Attack4")){
        GetComponent.<Animation>().CrossFade("Attack4"); 
        wings.GetComponent.<Animation>().CrossFade("Attack4");
    }
	if(GUILayout.Button("Wound")){
        GetComponent.<Animation>().CrossFade("Wound"); 
        wings.GetComponent.<Animation>().CrossFade("Wound");
    }
	if(GUILayout.Button("Stun")){
        GetComponent.<Animation>().CrossFade("Stun"); 
        wings.GetComponent.<Animation>().CrossFade("Stun");
    }
	if(GUILayout.Button("HitAway")){
        GetComponent.<Animation>().CrossFade("HitAway"); 
        wings.GetComponent.<Animation>().CrossFade("HitAway");
    }
	if(GUILayout.Button("HitAwayUp")){
        GetComponent.<Animation>().CrossFade("HitAwayUp"); 
        wings.GetComponent.<Animation>().CrossFade("HitAwayUp");
    }
	if(GUILayout.Button("Death")){
        GetComponent.<Animation>().CrossFade("Death"); 
        wings.GetComponent.<Animation>().CrossFade("Death");
    }
	if(GUILayout.Button("Magic")){
        GetComponent.<Animation>().CrossFade("Magic"); 
        wings.GetComponent.<Animation>().CrossFade("Magic");
    }
	if(GUILayout.Button("Fire")){
        GetComponent.<Animation>().CrossFade("Fire"); 
        wings.GetComponent.<Animation>().CrossFade("Fire");
    }
}
