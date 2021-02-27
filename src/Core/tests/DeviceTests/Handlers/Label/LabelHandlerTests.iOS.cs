using Microsoft.Maui.DeviceTests.Stubs;
using Microsoft.Maui.Handlers;
using System.Threading.Tasks;
using UIKit;
using Xunit;

namespace Microsoft.Maui.DeviceTests
{
	public partial class LabelHandlerTests
	{
		UILabel GetNativeLabel(LabelHandler labelHandler) =>
			(UILabel)labelHandler.View;

		string GetNativeText(LabelHandler labelHandler) =>
			 GetNativeLabel(labelHandler).Text;

		Color GetNativeTextColor(LabelHandler labelHandler) =>
			 GetNativeLabel(labelHandler).TextColor.ToColor();

		Task ValidateNativeBackgroundColor(ILabel label, Color color)
		{
			return InvokeOnMainThreadAsync(() =>
			{
				GetNativeLabel(CreateHandler(label)).AssertContainsColor(color);
			});
		}

		int GetNativeMaxLines(LabelHandler labelHandler) =>
			(int)GetNativeLabel(labelHandler).Lines;

		UILineBreakMode GetNativeLineBreakMode(LabelHandler labelHandler) =>
			GetNativeLabel(labelHandler).LineBreakMode;

		[Fact]
		public async Task NegativeMaxValueWithWrapIsCorrect()
		{
			var label = new LabelStub()
			{
				Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
				MaxLines = -1,
				LineBreakMode = LineBreakMode.WordWrap,
			};

			var nativeValue = await GetValueAsync(label, GetNativeMaxLines);

			Assert.Equal(0, nativeValue);
		}
	}
}