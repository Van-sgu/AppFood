; ModuleID = 'compressed_assemblies.arm64-v8a.ll'
source_filename = "compressed_assemblies.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android21"

%struct.CompressedAssemblyDescriptor = type {
	i32, ; uint32_t uncompressed_file_size
	i1, ; bool loaded
	i32 ; uint32_t buffer_offset
}

@compressed_assembly_count = dso_local local_unnamed_addr constant i32 206, align 4

@compressed_assembly_descriptors = dso_local local_unnamed_addr global [206 x %struct.CompressedAssemblyDescriptor] [
	%struct.CompressedAssemblyDescriptor {
		i32 257656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 0; uint32_t buffer_offset
	}, ; 0: Microsoft.Data.SqlClient.resources
	%struct.CompressedAssemblyDescriptor {
		i32 267384, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 257656; uint32_t buffer_offset
	}, ; 1: Microsoft.Data.SqlClient.resources
	%struct.CompressedAssemblyDescriptor {
		i32 259192, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 525040; uint32_t buffer_offset
	}, ; 2: Microsoft.Data.SqlClient.resources
	%struct.CompressedAssemblyDescriptor {
		i32 268408, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 784232; uint32_t buffer_offset
	}, ; 3: Microsoft.Data.SqlClient.resources
	%struct.CompressedAssemblyDescriptor {
		i32 260216, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 1052640; uint32_t buffer_offset
	}, ; 4: Microsoft.Data.SqlClient.resources
	%struct.CompressedAssemblyDescriptor {
		i32 289400, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 1312856; uint32_t buffer_offset
	}, ; 5: Microsoft.Data.SqlClient.resources
	%struct.CompressedAssemblyDescriptor {
		i32 267384, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 1602256; uint32_t buffer_offset
	}, ; 6: Microsoft.Data.SqlClient.resources
	%struct.CompressedAssemblyDescriptor {
		i32 266912, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 1869640; uint32_t buffer_offset
	}, ; 7: Microsoft.Data.SqlClient.resources
	%struct.CompressedAssemblyDescriptor {
		i32 255096, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 2136552; uint32_t buffer_offset
	}, ; 8: Microsoft.Data.SqlClient.resources
	%struct.CompressedAssemblyDescriptor {
		i32 344736, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 2391648; uint32_t buffer_offset
	}, ; 9: Microsoft.Data.SqlClient.resources
	%struct.CompressedAssemblyDescriptor {
		i32 250488, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 2736384; uint32_t buffer_offset
	}, ; 10: Microsoft.Data.SqlClient.resources
	%struct.CompressedAssemblyDescriptor {
		i32 225912, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 2986872; uint32_t buffer_offset
	}, ; 11: Microsoft.Data.SqlClient.resources
	%struct.CompressedAssemblyDescriptor {
		i32 229496, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3212784; uint32_t buffer_offset
	}, ; 12: Microsoft.Data.SqlClient.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3442280; uint32_t buffer_offset
	}, ; 13: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3457912; uint32_t buffer_offset
	}, ; 14: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3473544; uint32_t buffer_offset
	}, ; 15: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3489176; uint32_t buffer_offset
	}, ; 16: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3504848; uint32_t buffer_offset
	}, ; 17: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3520480; uint32_t buffer_offset
	}, ; 18: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3536112; uint32_t buffer_offset
	}, ; 19: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3551744; uint32_t buffer_offset
	}, ; 20: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3567376; uint32_t buffer_offset
	}, ; 21: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3583048; uint32_t buffer_offset
	}, ; 22: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3598680; uint32_t buffer_offset
	}, ; 23: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3614352; uint32_t buffer_offset
	}, ; 24: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3630024; uint32_t buffer_offset
	}, ; 25: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3645648; uint32_t buffer_offset
	}, ; 26: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3661272; uint32_t buffer_offset
	}, ; 27: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3676896; uint32_t buffer_offset
	}, ; 28: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3692520; uint32_t buffer_offset
	}, ; 29: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3708192; uint32_t buffer_offset
	}, ; 30: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3723864; uint32_t buffer_offset
	}, ; 31: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3739496; uint32_t buffer_offset
	}, ; 32: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3755120; uint32_t buffer_offset
	}, ; 33: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3770752; uint32_t buffer_offset
	}, ; 34: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3786384; uint32_t buffer_offset
	}, ; 35: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3802008; uint32_t buffer_offset
	}, ; 36: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3817632; uint32_t buffer_offset
	}, ; 37: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3833264; uint32_t buffer_offset
	}, ; 38: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3848888; uint32_t buffer_offset
	}, ; 39: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3864520; uint32_t buffer_offset
	}, ; 40: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3880192; uint32_t buffer_offset
	}, ; 41: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3895824; uint32_t buffer_offset
	}, ; 42: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3911448; uint32_t buffer_offset
	}, ; 43: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3927080; uint32_t buffer_offset
	}, ; 44: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3942712; uint32_t buffer_offset
	}, ; 45: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3958336; uint32_t buffer_offset
	}, ; 46: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 6144, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3974008; uint32_t buffer_offset
	}, ; 47: _Microsoft.Android.Resource.Designer
	%struct.CompressedAssemblyDescriptor {
		i32 438856, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3980152; uint32_t buffer_offset
	}, ; 48: Azure.Core
	%struct.CompressedAssemblyDescriptor {
		i32 237056, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 4419008; uint32_t buffer_offset
	}, ; 49: Azure.Identity
	%struct.CompressedAssemblyDescriptor {
		i32 246784, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 4656064; uint32_t buffer_offset
	}, ; 50: Dapper
	%struct.CompressedAssemblyDescriptor {
		i32 2104992, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 4902848; uint32_t buffer_offset
	}, ; 51: Microsoft.Data.SqlClient
	%struct.CompressedAssemblyDescriptor {
		i32 11264, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7007840; uint32_t buffer_offset
	}, ; 52: Microsoft.Extensions.Caching.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 26624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7019104; uint32_t buffer_offset
	}, ; 53: Microsoft.Extensions.Caching.Memory
	%struct.CompressedAssemblyDescriptor {
		i32 14848, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7045728; uint32_t buffer_offset
	}, ; 54: Microsoft.Extensions.Configuration
	%struct.CompressedAssemblyDescriptor {
		i32 6656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7060576; uint32_t buffer_offset
	}, ; 55: Microsoft.Extensions.Configuration.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 47104, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7067232; uint32_t buffer_offset
	}, ; 56: Microsoft.Extensions.DependencyInjection
	%struct.CompressedAssemblyDescriptor {
		i32 26624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7114336; uint32_t buffer_offset
	}, ; 57: Microsoft.Extensions.DependencyInjection.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 8192, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7140960; uint32_t buffer_offset
	}, ; 58: Microsoft.Extensions.Diagnostics.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 7168, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7149152; uint32_t buffer_offset
	}, ; 59: Microsoft.Extensions.FileProviders.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 6144, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7156320; uint32_t buffer_offset
	}, ; 60: Microsoft.Extensions.Hosting.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 17920, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7162464; uint32_t buffer_offset
	}, ; 61: Microsoft.Extensions.Logging
	%struct.CompressedAssemblyDescriptor {
		i32 19456, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7180384; uint32_t buffer_offset
	}, ; 62: Microsoft.Extensions.Logging.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 16896, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7199840; uint32_t buffer_offset
	}, ; 63: Microsoft.Extensions.Options
	%struct.CompressedAssemblyDescriptor {
		i32 9216, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7216736; uint32_t buffer_offset
	}, ; 64: Microsoft.Extensions.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 1103360, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7225952; uint32_t buffer_offset
	}, ; 65: Microsoft.Identity.Client
	%struct.CompressedAssemblyDescriptor {
		i32 46592, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 8329312; uint32_t buffer_offset
	}, ; 66: Microsoft.Identity.Client.Extensions.Msal
	%struct.CompressedAssemblyDescriptor {
		i32 6144, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 8375904; uint32_t buffer_offset
	}, ; 67: Microsoft.IdentityModel.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 137760, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 8382048; uint32_t buffer_offset
	}, ; 68: Microsoft.IdentityModel.JsonWebTokens
	%struct.CompressedAssemblyDescriptor {
		i32 17408, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 8519808; uint32_t buffer_offset
	}, ; 69: Microsoft.IdentityModel.Logging
	%struct.CompressedAssemblyDescriptor {
		i32 40992, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 8537216; uint32_t buffer_offset
	}, ; 70: Microsoft.IdentityModel.Protocols
	%struct.CompressedAssemblyDescriptor {
		i32 128032, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 8578208; uint32_t buffer_offset
	}, ; 71: Microsoft.IdentityModel.Protocols.OpenIdConnect
	%struct.CompressedAssemblyDescriptor {
		i32 300064, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 8706240; uint32_t buffer_offset
	}, ; 72: Microsoft.IdentityModel.Tokens
	%struct.CompressedAssemblyDescriptor {
		i32 1925384, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 9006304; uint32_t buffer_offset
	}, ; 73: Microsoft.Maui.Controls
	%struct.CompressedAssemblyDescriptor {
		i32 37136, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 10931688; uint32_t buffer_offset
	}, ; 74: Microsoft.Maui.Controls.Maps
	%struct.CompressedAssemblyDescriptor {
		i32 133392, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 10968824; uint32_t buffer_offset
	}, ; 75: Microsoft.Maui.Controls.Xaml
	%struct.CompressedAssemblyDescriptor {
		i32 853504, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 11102216; uint32_t buffer_offset
	}, ; 76: Microsoft.Maui
	%struct.CompressedAssemblyDescriptor {
		i32 82944, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 11955720; uint32_t buffer_offset
	}, ; 77: Microsoft.Maui.Essentials
	%struct.CompressedAssemblyDescriptor {
		i32 208696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 12038664; uint32_t buffer_offset
	}, ; 78: Microsoft.Maui.Graphics
	%struct.CompressedAssemblyDescriptor {
		i32 47416, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 12247360; uint32_t buffer_offset
	}, ; 79: Microsoft.Maui.Maps
	%struct.CompressedAssemblyDescriptor {
		i32 23976, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 12294776; uint32_t buffer_offset
	}, ; 80: Microsoft.SqlServer.Server
	%struct.CompressedAssemblyDescriptor {
		i32 107520, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 12318752; uint32_t buffer_offset
	}, ; 81: SQLite-net
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 12426272; uint32_t buffer_offset
	}, ; 82: SQLitePCLRaw.batteries_v2
	%struct.CompressedAssemblyDescriptor {
		i32 51200, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 12431904; uint32_t buffer_offset
	}, ; 83: SQLitePCLRaw.core
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 12483104; uint32_t buffer_offset
	}, ; 84: SQLitePCLRaw.lib.e_sqlite3.android
	%struct.CompressedAssemblyDescriptor {
		i32 36864, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 12488224; uint32_t buffer_offset
	}, ; 85: SQLitePCLRaw.provider.e_sqlite3
	%struct.CompressedAssemblyDescriptor {
		i32 36352, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 12525088; uint32_t buffer_offset
	}, ; 86: System.ClientModel
	%struct.CompressedAssemblyDescriptor {
		i32 443176, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 12561440; uint32_t buffer_offset
	}, ; 87: System.Configuration.ConfigurationManager
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 13004616; uint32_t buffer_offset
	}, ; 88: System.Diagnostics.EventLog
	%struct.CompressedAssemblyDescriptor {
		i32 89016, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 13010248; uint32_t buffer_offset
	}, ; 89: System.IdentityModel.Tokens.Jwt
	%struct.CompressedAssemblyDescriptor {
		i32 11264, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 13099264; uint32_t buffer_offset
	}, ; 90: System.Memory.Data
	%struct.CompressedAssemblyDescriptor {
		i32 19456, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 13110528; uint32_t buffer_offset
	}, ; 91: System.Security.Cryptography.Pkcs
	%struct.CompressedAssemblyDescriptor {
		i32 10752, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 13129984; uint32_t buffer_offset
	}, ; 92: System.Security.Cryptography.ProtectedData
	%struct.CompressedAssemblyDescriptor {
		i32 73728, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 13140736; uint32_t buffer_offset
	}, ; 93: Xamarin.AndroidX.Activity
	%struct.CompressedAssemblyDescriptor {
		i32 583680, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 13214464; uint32_t buffer_offset
	}, ; 94: Xamarin.AndroidX.AppCompat
	%struct.CompressedAssemblyDescriptor {
		i32 17920, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 13798144; uint32_t buffer_offset
	}, ; 95: Xamarin.AndroidX.AppCompat.AppCompatResources
	%struct.CompressedAssemblyDescriptor {
		i32 50176, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 13816064; uint32_t buffer_offset
	}, ; 96: Xamarin.AndroidX.Browser
	%struct.CompressedAssemblyDescriptor {
		i32 18944, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 13866240; uint32_t buffer_offset
	}, ; 97: Xamarin.AndroidX.CardView
	%struct.CompressedAssemblyDescriptor {
		i32 22528, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 13885184; uint32_t buffer_offset
	}, ; 98: Xamarin.AndroidX.Collection.Jvm
	%struct.CompressedAssemblyDescriptor {
		i32 78336, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 13907712; uint32_t buffer_offset
	}, ; 99: Xamarin.AndroidX.CoordinatorLayout
	%struct.CompressedAssemblyDescriptor {
		i32 611840, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 13986048; uint32_t buffer_offset
	}, ; 100: Xamarin.AndroidX.Core
	%struct.CompressedAssemblyDescriptor {
		i32 26624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 14597888; uint32_t buffer_offset
	}, ; 101: Xamarin.AndroidX.CursorAdapter
	%struct.CompressedAssemblyDescriptor {
		i32 9728, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 14624512; uint32_t buffer_offset
	}, ; 102: Xamarin.AndroidX.CustomView
	%struct.CompressedAssemblyDescriptor {
		i32 47104, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 14634240; uint32_t buffer_offset
	}, ; 103: Xamarin.AndroidX.DrawerLayout
	%struct.CompressedAssemblyDescriptor {
		i32 236032, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 14681344; uint32_t buffer_offset
	}, ; 104: Xamarin.AndroidX.Fragment
	%struct.CompressedAssemblyDescriptor {
		i32 23552, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 14917376; uint32_t buffer_offset
	}, ; 105: Xamarin.AndroidX.Lifecycle.Common.Jvm
	%struct.CompressedAssemblyDescriptor {
		i32 18944, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 14940928; uint32_t buffer_offset
	}, ; 106: Xamarin.AndroidX.Lifecycle.LiveData.Core
	%struct.CompressedAssemblyDescriptor {
		i32 32768, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 14959872; uint32_t buffer_offset
	}, ; 107: Xamarin.AndroidX.Lifecycle.ViewModel.Android
	%struct.CompressedAssemblyDescriptor {
		i32 13824, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 14992640; uint32_t buffer_offset
	}, ; 108: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.Android
	%struct.CompressedAssemblyDescriptor {
		i32 39424, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15006464; uint32_t buffer_offset
	}, ; 109: Xamarin.AndroidX.Loader
	%struct.CompressedAssemblyDescriptor {
		i32 92672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15045888; uint32_t buffer_offset
	}, ; 110: Xamarin.AndroidX.Navigation.Common.Android
	%struct.CompressedAssemblyDescriptor {
		i32 19456, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15138560; uint32_t buffer_offset
	}, ; 111: Xamarin.AndroidX.Navigation.Fragment
	%struct.CompressedAssemblyDescriptor {
		i32 65536, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15158016; uint32_t buffer_offset
	}, ; 112: Xamarin.AndroidX.Navigation.Runtime.Android
	%struct.CompressedAssemblyDescriptor {
		i32 27136, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15223552; uint32_t buffer_offset
	}, ; 113: Xamarin.AndroidX.Navigation.UI
	%struct.CompressedAssemblyDescriptor {
		i32 457728, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15250688; uint32_t buffer_offset
	}, ; 114: Xamarin.AndroidX.RecyclerView
	%struct.CompressedAssemblyDescriptor {
		i32 12288, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15708416; uint32_t buffer_offset
	}, ; 115: Xamarin.AndroidX.SavedState.SavedState.Android
	%struct.CompressedAssemblyDescriptor {
		i32 41984, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15720704; uint32_t buffer_offset
	}, ; 116: Xamarin.AndroidX.SwipeRefreshLayout
	%struct.CompressedAssemblyDescriptor {
		i32 62976, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15762688; uint32_t buffer_offset
	}, ; 117: Xamarin.AndroidX.ViewPager
	%struct.CompressedAssemblyDescriptor {
		i32 40448, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15825664; uint32_t buffer_offset
	}, ; 118: Xamarin.AndroidX.ViewPager2
	%struct.CompressedAssemblyDescriptor {
		i32 675840, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15866112; uint32_t buffer_offset
	}, ; 119: Xamarin.Google.Android.Material
	%struct.CompressedAssemblyDescriptor {
		i32 212992, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16541952; uint32_t buffer_offset
	}, ; 120: Xamarin.GooglePlayServices.Base
	%struct.CompressedAssemblyDescriptor {
		i32 71680, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16754944; uint32_t buffer_offset
	}, ; 121: Xamarin.GooglePlayServices.Basement
	%struct.CompressedAssemblyDescriptor {
		i32 318464, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16826624; uint32_t buffer_offset
	}, ; 122: Xamarin.GooglePlayServices.Maps
	%struct.CompressedAssemblyDescriptor {
		i32 52736, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17145088; uint32_t buffer_offset
	}, ; 123: Xamarin.GooglePlayServices.Tasks
	%struct.CompressedAssemblyDescriptor {
		i32 90624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17197824; uint32_t buffer_offset
	}, ; 124: Xamarin.Kotlin.StdLib
	%struct.CompressedAssemblyDescriptor {
		i32 28672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17288448; uint32_t buffer_offset
	}, ; 125: Xamarin.KotlinX.Coroutines.Core.Jvm
	%struct.CompressedAssemblyDescriptor {
		i32 91648, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17317120; uint32_t buffer_offset
	}, ; 126: Xamarin.KotlinX.Serialization.Core.Jvm
	%struct.CompressedAssemblyDescriptor {
		i32 121344, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17408768; uint32_t buffer_offset
	}, ; 127: AppFood
	%struct.CompressedAssemblyDescriptor {
		i32 231424, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17530112; uint32_t buffer_offset
	}, ; 128: Microsoft.CSharp
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17761536; uint32_t buffer_offset
	}, ; 129: Microsoft.Win32.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 34304, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17766656; uint32_t buffer_offset
	}, ; 130: System.Collections.Concurrent
	%struct.CompressedAssemblyDescriptor {
		i32 32256, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17800960; uint32_t buffer_offset
	}, ; 131: System.Collections.Immutable
	%struct.CompressedAssemblyDescriptor {
		i32 19456, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17833216; uint32_t buffer_offset
	}, ; 132: System.Collections.NonGeneric
	%struct.CompressedAssemblyDescriptor {
		i32 24064, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17852672; uint32_t buffer_offset
	}, ; 133: System.Collections.Specialized
	%struct.CompressedAssemblyDescriptor {
		i32 55808, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17876736; uint32_t buffer_offset
	}, ; 134: System.Collections
	%struct.CompressedAssemblyDescriptor {
		i32 17920, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17932544; uint32_t buffer_offset
	}, ; 135: System.ComponentModel.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 162304, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17950464; uint32_t buffer_offset
	}, ; 136: System.ComponentModel.TypeConverter
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18112768; uint32_t buffer_offset
	}, ; 137: System.ComponentModel
	%struct.CompressedAssemblyDescriptor {
		i32 12288, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18118400; uint32_t buffer_offset
	}, ; 138: System.Console
	%struct.CompressedAssemblyDescriptor {
		i32 616960, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18130688; uint32_t buffer_offset
	}, ; 139: System.Data.Common
	%struct.CompressedAssemblyDescriptor {
		i32 65024, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18747648; uint32_t buffer_offset
	}, ; 140: System.Diagnostics.DiagnosticSource
	%struct.CompressedAssemblyDescriptor {
		i32 65024, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18812672; uint32_t buffer_offset
	}, ; 141: System.Diagnostics.Process
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18877696; uint32_t buffer_offset
	}, ; 142: System.Diagnostics.StackTrace
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18882816; uint32_t buffer_offset
	}, ; 143: System.Diagnostics.TextWriterTraceListener
	%struct.CompressedAssemblyDescriptor {
		i32 26624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18888448; uint32_t buffer_offset
	}, ; 144: System.Diagnostics.TraceSource
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18915072; uint32_t buffer_offset
	}, ; 145: System.Diagnostics.Tracing
	%struct.CompressedAssemblyDescriptor {
		i32 40960, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18920704; uint32_t buffer_offset
	}, ; 146: System.Drawing.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18961664; uint32_t buffer_offset
	}, ; 147: System.Drawing
	%struct.CompressedAssemblyDescriptor {
		i32 63488, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18966784; uint32_t buffer_offset
	}, ; 148: System.Formats.Asn1
	%struct.CompressedAssemblyDescriptor {
		i32 22016, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 19030272; uint32_t buffer_offset
	}, ; 149: System.IO.Compression.Brotli
	%struct.CompressedAssemblyDescriptor {
		i32 33792, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 19052288; uint32_t buffer_offset
	}, ; 150: System.IO.Compression
	%struct.CompressedAssemblyDescriptor {
		i32 7168, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 19086080; uint32_t buffer_offset
	}, ; 151: System.IO.FileSystem.AccessControl
	%struct.CompressedAssemblyDescriptor {
		i32 30720, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 19093248; uint32_t buffer_offset
	}, ; 152: System.IO.FileSystem.Watcher
	%struct.CompressedAssemblyDescriptor {
		i32 7168, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 19123968; uint32_t buffer_offset
	}, ; 153: System.IO.Pipelines
	%struct.CompressedAssemblyDescriptor {
		i32 27648, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 19131136; uint32_t buffer_offset
	}, ; 154: System.IO.Pipes
	%struct.CompressedAssemblyDescriptor {
		i32 432128, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 19158784; uint32_t buffer_offset
	}, ; 155: System.Linq.Expressions
	%struct.CompressedAssemblyDescriptor {
		i32 75264, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 19590912; uint32_t buffer_offset
	}, ; 156: System.Linq
	%struct.CompressedAssemblyDescriptor {
		i32 17408, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 19666176; uint32_t buffer_offset
	}, ; 157: System.Memory
	%struct.CompressedAssemblyDescriptor {
		i32 395264, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 19683584; uint32_t buffer_offset
	}, ; 158: System.Net.Http
	%struct.CompressedAssemblyDescriptor {
		i32 29184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 20078848; uint32_t buffer_offset
	}, ; 159: System.Net.NameResolution
	%struct.CompressedAssemblyDescriptor {
		i32 26112, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 20108032; uint32_t buffer_offset
	}, ; 160: System.Net.NetworkInformation
	%struct.CompressedAssemblyDescriptor {
		i32 70144, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 20134144; uint32_t buffer_offset
	}, ; 161: System.Net.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 90112, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 20204288; uint32_t buffer_offset
	}, ; 162: System.Net.Requests
	%struct.CompressedAssemblyDescriptor {
		i32 151040, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 20294400; uint32_t buffer_offset
	}, ; 163: System.Net.Security
	%struct.CompressedAssemblyDescriptor {
		i32 121856, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 20445440; uint32_t buffer_offset
	}, ; 164: System.Net.Sockets
	%struct.CompressedAssemblyDescriptor {
		i32 12288, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 20567296; uint32_t buffer_offset
	}, ; 165: System.Net.WebClient
	%struct.CompressedAssemblyDescriptor {
		i32 10240, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 20579584; uint32_t buffer_offset
	}, ; 166: System.Net.WebHeaderCollection
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 20589824; uint32_t buffer_offset
	}, ; 167: System.Numerics.Vectors
	%struct.CompressedAssemblyDescriptor {
		i32 20992, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 20594944; uint32_t buffer_offset
	}, ; 168: System.ObjectModel
	%struct.CompressedAssemblyDescriptor {
		i32 78336, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 20615936; uint32_t buffer_offset
	}, ; 169: System.Private.Uri
	%struct.CompressedAssemblyDescriptor {
		i32 57344, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 20694272; uint32_t buffer_offset
	}, ; 170: System.Private.Xml.Linq
	%struct.CompressedAssemblyDescriptor {
		i32 1599488, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 20751616; uint32_t buffer_offset
	}, ; 171: System.Private.Xml
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 22351104; uint32_t buffer_offset
	}, ; 172: System.Reflection.Emit.ILGeneration
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 22356224; uint32_t buffer_offset
	}, ; 173: System.Reflection.Emit.Lightweight
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 22361344; uint32_t buffer_offset
	}, ; 174: System.Reflection.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 22366464; uint32_t buffer_offset
	}, ; 175: System.Runtime.InteropServices.RuntimeInformation
	%struct.CompressedAssemblyDescriptor {
		i32 9216, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 22371584; uint32_t buffer_offset
	}, ; 176: System.Runtime.InteropServices
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 22380800; uint32_t buffer_offset
	}, ; 177: System.Runtime.Loader
	%struct.CompressedAssemblyDescriptor {
		i32 94720, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 22385920; uint32_t buffer_offset
	}, ; 178: System.Runtime.Numerics
	%struct.CompressedAssemblyDescriptor {
		i32 8192, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 22480640; uint32_t buffer_offset
	}, ; 179: System.Runtime.Serialization.Formatters
	%struct.CompressedAssemblyDescriptor {
		i32 6144, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 22488832; uint32_t buffer_offset
	}, ; 180: System.Runtime.Serialization.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 17920, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 22494976; uint32_t buffer_offset
	}, ; 181: System.Runtime
	%struct.CompressedAssemblyDescriptor {
		i32 6656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 22512896; uint32_t buffer_offset
	}, ; 182: System.Security.AccessControl
	%struct.CompressedAssemblyDescriptor {
		i32 15360, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 22519552; uint32_t buffer_offset
	}, ; 183: System.Security.Claims
	%struct.CompressedAssemblyDescriptor {
		i32 308736, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 22534912; uint32_t buffer_offset
	}, ; 184: System.Security.Cryptography
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 22843648; uint32_t buffer_offset
	}, ; 185: System.Security.Principal.Windows
	%struct.CompressedAssemblyDescriptor {
		i32 699904, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 22849280; uint32_t buffer_offset
	}, ; 186: System.Text.Encoding.CodePages
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 23549184; uint32_t buffer_offset
	}, ; 187: System.Text.Encoding.Extensions
	%struct.CompressedAssemblyDescriptor {
		i32 29696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 23554304; uint32_t buffer_offset
	}, ; 188: System.Text.Encodings.Web
	%struct.CompressedAssemblyDescriptor {
		i32 425984, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 23584000; uint32_t buffer_offset
	}, ; 189: System.Text.Json
	%struct.CompressedAssemblyDescriptor {
		i32 336896, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 24009984; uint32_t buffer_offset
	}, ; 190: System.Text.RegularExpressions
	%struct.CompressedAssemblyDescriptor {
		i32 24064, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 24346880; uint32_t buffer_offset
	}, ; 191: System.Threading.Channels
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 24370944; uint32_t buffer_offset
	}, ; 192: System.Threading.Thread
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 24376064; uint32_t buffer_offset
	}, ; 193: System.Threading.ThreadPool
	%struct.CompressedAssemblyDescriptor {
		i32 11264, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 24381184; uint32_t buffer_offset
	}, ; 194: System.Threading
	%struct.CompressedAssemblyDescriptor {
		i32 12800, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 24392448; uint32_t buffer_offset
	}, ; 195: System.Transactions.Local
	%struct.CompressedAssemblyDescriptor {
		i32 4608, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 24405248; uint32_t buffer_offset
	}, ; 196: System.Xml.Linq
	%struct.CompressedAssemblyDescriptor {
		i32 6144, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 24409856; uint32_t buffer_offset
	}, ; 197: System.Xml.ReaderWriter
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 24416000; uint32_t buffer_offset
	}, ; 198: System.Xml.XDocument
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 24421120; uint32_t buffer_offset
	}, ; 199: System.Xml.XmlSerializer
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 24426240; uint32_t buffer_offset
	}, ; 200: System
	%struct.CompressedAssemblyDescriptor {
		i32 9728, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 24431360; uint32_t buffer_offset
	}, ; 201: netstandard
	%struct.CompressedAssemblyDescriptor {
		i32 2395136, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 24441088; uint32_t buffer_offset
	}, ; 202: System.Private.CoreLib
	%struct.CompressedAssemblyDescriptor {
		i32 172032, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 26836224; uint32_t buffer_offset
	}, ; 203: Java.Interop
	%struct.CompressedAssemblyDescriptor {
		i32 21536, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 27008256; uint32_t buffer_offset
	}, ; 204: Mono.Android.Runtime
	%struct.CompressedAssemblyDescriptor {
		i32 2148352, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 27029792; uint32_t buffer_offset
	} ; 205: Mono.Android
], align 4

@uncompressed_assemblies_data_size = dso_local local_unnamed_addr constant i32 29178144, align 4

@uncompressed_assemblies_data_buffer = dso_local local_unnamed_addr global [29178144 x i8] zeroinitializer, align 1

; Metadata
!llvm.module.flags = !{!0, !1, !7, !8, !9, !10}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!".NET for Android remotes/origin/release/10.0.1xx @ 01024bb616e7b80417a2c6d320885bfdb956f20a"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"branch-target-enforcement", i32 0}
!8 = !{i32 1, !"sign-return-address", i32 0}
!9 = !{i32 1, !"sign-return-address-all", i32 0}
!10 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
