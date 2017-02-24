using System;
using ObjCRuntime;
using Foundation;
using UIKit;

namespace Binding_SMSSDK
{
    // The first step to creating a binding is to add your native library ("libNativeLibrary.a")
    // to the project by right-clicking (or Control-clicking) the folder containing this source
    // file and clicking "Add files..." and then simply select the native library (or libraries)
    // that you want to bind.
    //
    // When you do that, you'll notice that MonoDevelop generates a code-behind file for each
    // native library which will contain a [LinkWith] attribute. VisualStudio auto-detects the
    // architectures that the native library supports and fills in that information for you,
    // however, it cannot auto-detect any Frameworks or other system libraries that the
    // native library may depend on, so you'll need to fill in that information yourself.
    //
    // Once you've done that, you're ready to move on to binding the API...
    //
    //
    // Here is where you'd define your API definition for the native Objective-C library.
    //
    // For example, to bind the following Objective-C class:
    //
    //     @interface Widget : NSObject {
    //     }
    //
    // The C# binding would look like this:
    //
    //     [BaseType (typeof (NSObject))]
    //     interface Widget {
    //     }
    //
    // To bind Objective-C properties, such as:
    //
    //     @property (nonatomic, readwrite, assign) CGPoint center;
    //
    // You would add a property definition in the C# interface like so:
    //
    //     [Export ("center")]
    //     CGPoint Center { get; set; }
    //
    // To bind an Objective-C method, such as:
    //
    //     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
    //
    // You would add a method definition to the C# interface like so:
    //
    //     [Export ("doSomething:atIndex:")]
    //     void DoSomething (NSObject object, int index);
    //
    // Objective-C "constructors" such as:
    //
    //     -(id)initWithElmo:(ElmoMuppet *)elmo;
    //
    // Can be bound as:
    //
    //     [Export ("initWithElmo:")]
    //     IntPtr Constructor (ElmoMuppet elmo);
    //
    // For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_types
    //

   // typedef void (^SMSGetCodeResultHandler)(NSError *);
    delegate void SMSGetCodeResultHandler(NSError arg0);

    // typedef void (^SMSCommitCodeResultHandler)(SMSSDKUserInfo *, NSError *);
    delegate void SMSCommitCodeResultHandler(SMSSDKUserInfo arg0, NSError arg1);

    // typedef void (^SMSCommitVerifyCodeBlock)(enum SMSResponseState);
    delegate void SMSCommitVerifyCodeBlock(SMSResponseState arg0);

    // typedef void (^SMSGetZoneResultHandler)(NSError *, NSArray *);
    delegate void SMSGetZoneResultHandler(NSError arg0, NSObject[] arg1);

    // typedef void (^SMSGetZoneBlock)(enum SMSResponseState, NSArray *);
    delegate void SMSGetZoneBlock(SMSResponseState arg0, NSObject[] arg1);

    // typedef void (^SMSGetAllContactFriendsResultHandler)(NSError *, NSArray *);
    delegate void SMSGetAllContactFriendsResultHandler(NSError arg0, NSObject[] arg1);

    // typedef void (^SMSGetAppContactFriendsBlock)(enum SMSResponseState, NSArray *);
    delegate void SMSGetAppContactFriendsBlock(SMSResponseState arg0, NSObject[] arg1);

    // typedef void (^SMSSubmitUserInfoResultHandler)(NSError *);
    delegate void SMSSubmitUserInfoResultHandler(NSError arg0);

    // typedef void (^SMSSubmitUserInfoBlock)(enum SMSResponseState);
    delegate void SMSSubmitUserInfoBlock(SMSResponseState arg0);

    // typedef void (^SMSShowNewFriendsCountBlock)(enum SMSResponseState, int);
    delegate void SMSShowNewFriendsCountBlock(SMSResponseState arg0, int arg1);

    // typedef void (^SMSUIVerificationCodeResultHandler)(enum SMSUIResponseState state,NSString *phoneNumber,NSString *zone,NSError *error);
    delegate void SMSUIVerificationCodeResultHandler(SMSUIResponseState state, string phoneNumber, string zone, NSError error);

    [BaseType(typeof(NSObject))]
    interface SMSSDKUI
    {
        // +(id)showVerificationCodeViewWithMetohd:(id)whichMethod result:(id)result;
        [Static]
        [Export("showVerificationCodeViewWithMetohd:result:")]
        NSObject ShowVerificationCodeViewWithMetohd(SMSGetCodeMethod whichMethod, SMSUIVerificationCodeResultHandler result);

        // +(id)showGetContactsFriendsViewWithNewFriends:(NSMutableArray *)newFriends newFriendClock:(id)newFriendsCountBlock result:(id)result;
        [Static]
        [Export("showGetContactsFriendsViewWithNewFriends:newFriendClock:result:")]
        NSObject ShowGetContactsFriendsViewWithNewFriends(NSMutableArray newFriends, NSObject newFriendsCountBlock, NSObject result);
    }

    // @interface SMSSDKUserInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface SMSSDKUserInfo
    {
        // @property (copy, nonatomic) NSString * avatar;
        [Export("avatar")]
        string Avatar { get; set; }

        // @property (copy, nonatomic) NSString * uid;
        [Export("uid")]
        string Uid { get; set; }

        // @property (copy, nonatomic) NSString * nickname;
        [Export("nickname")]
        string Nickname { get; set; }

        // @property (copy, nonatomic) NSString * phone;
        [Export("phone")]
        string Phone { get; set; }

        // @property (copy, nonatomic) NSString * zone;
        [Export("zone")]
        string Zone { get; set; }
    }

    // @interface SMSSDK : NSObject
    [BaseType(typeof(NSObject))]
    interface SMSSDK
    {
        // +(void)registerApp:(NSString *)appKey withSecret:(NSString *)appSecret;
        [Static]
        [Export("registerApp:withSecret:")]
        void RegisterApp(string appKey, string appSecret);

        // +(void)getVerificationCodeByMethod:(SMSGetCodeMethod)method phoneNumber:(NSString *)phoneNumber zone:(NSString *)zone customIdentifier:(NSString *)customIdentifier result:(SMSGetCodeResultHandler)result;
        [Static]
        [Export("getVerificationCodeByMethod:phoneNumber:zone:customIdentifier:result:")]
        void GetVerificationCodeByMethod(SMSGetCodeMethod method, string phoneNumber, string zone, string customIdentifier, SMSGetCodeResultHandler result);

        // +(void)commitVerificationCode:(NSString *)code phoneNumber:(NSString *)phoneNumber zone:(NSString *)zone result:(SMSCommitCodeResultHandler)result;
        [Static]
        [Export("commitVerificationCode:phoneNumber:zone:result:")]
        void CommitVerificationCode(string code, string phoneNumber, string zone, SMSCommitCodeResultHandler result);

        // +(NSString *)SMSSDKVersion;
        [Static]
        [Export("SMSSDKVersion")]
        //[Verify(MethodToProperty)]
        string SMSSDKVersion { get; }
    }
}

