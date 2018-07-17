// uScript Action Node
// (C) 2015 Detox Studios LLC
#if (UNITY_4_6 || UNITY_4_7 || UNITY_5 || UNITY_2017)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Gets the specified parameter of a Animator Controller on the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Animator Parameter (Float)", "Gets the specified parameter of a Animator Controller on the target GameObject.")]
public class uScriptAct_AnimatorGetParameterFloat : uScriptLogic
{

   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The target GameObject that contains the Animator Controller component with the paremeter you wish to get."), AutoLinkType(typeof(GameObject))]
      GameObject Target,

      [FriendlyName("Name", "The name of the parameter you wish to get.")]
      string Name,

      [FriendlyName("Value", "The value of the specified paramater.")]
      out float Value
      )
   {
      float tmpValue = 0f;

      Animator animController = Target.GetComponent<Animator>();
      if (null != animController)
      {
         tmpValue = animController.GetFloat(Name);
      }
      else
      {
         uScriptDebug.Log("The specified Target does not have an Animator Controller component. Returning 0.");
      }

      Value = tmpValue;       
   }

}
#endif
