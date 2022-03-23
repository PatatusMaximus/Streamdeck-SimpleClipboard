using StreamDeckLib;
using StreamDeckLib.Messages;
using System.Threading.Tasks;
using SimpleClipboard.models;

namespace SimpleClipboard
{
  [ActionUuid(Uuid="com.patatusmaximus.simplecliboard.set.DefaultPluginAction")]
  public class SimpleClipboardAction : BaseStreamDeckActionWithSettingsModel<ClipboardSettingsModel>
  {
	  
	public override async Task OnKeyDown(StreamDeckEventPayload args)
	{
		await base.OnKeyDown(args);
		await TextCopy.ClipboardService.SetTextAsync(SettingsModel.Value);
	}

	public override async Task OnDidReceiveSettings(StreamDeckEventPayload args)
	{
	  await base.OnDidReceiveSettings(args);
	  await Manager.SetTitleAsync(args.context, SettingsModel.Value);
	}

	public override async Task OnWillAppear(StreamDeckEventPayload args)
	{
	  await base.OnWillAppear(args);
	  await Manager.SetTitleAsync(args.context, SettingsModel.Value);
	}

  }
}
