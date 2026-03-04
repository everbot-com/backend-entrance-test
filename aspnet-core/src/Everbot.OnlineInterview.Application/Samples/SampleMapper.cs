using System.Net;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace Everbot.OnlineInterview.Samples;

[Mapper]
public partial class SampleToSampleDtoMapper : TwoWayMapperBase<Sample, SampleDto>
{
    [MapperIgnoreSource(nameof(Sample.IPAddress))]
    [MapperIgnoreSource(nameof(Sample.ConcurrencyStamp))]
    [MapperIgnoreTarget(nameof(SampleDto.IPAddress))]
    public override partial SampleDto Map(Sample source);

    [MapperIgnoreSource(nameof(Sample.IPAddress))]
    [MapperIgnoreSource(nameof(Sample.ConcurrencyStamp))]
    [MapperIgnoreTarget(nameof(SampleDto.IPAddress))]
    public override partial void Map(Sample source, SampleDto destination);

    public override void AfterMap(Sample source, SampleDto destination)
    {
        destination.IPAddress = source.IPAddress?.ToString() ?? string.Empty;
    }

    [MapperIgnoreSource(nameof(SampleDto.IPAddress))]
    [MapperIgnoreTarget(nameof(Sample.ConcurrencyStamp))]
    [MapperIgnoreTarget(nameof(Sample.IPAddress))]
    public override partial Sample ReverseMap(SampleDto destination);

    [MapperIgnoreSource(nameof(SampleDto.IPAddress))]
    [MapperIgnoreTarget(nameof(Sample.ConcurrencyStamp))]
    [MapperIgnoreTarget(nameof(Sample.IPAddress))]
    public override partial void ReverseMap(SampleDto destination, Sample source);

    public override void AfterReverseMap(SampleDto destination, Sample source)
    {
        source.IPAddress = IPAddress.TryParse(destination.IPAddress, out var ip) ? ip : null;
    }
}
