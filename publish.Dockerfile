FROM fabiolune/nginx-custom-backend:build AS build

ARG TARGETPLATFORM

ENV rid=
RUN if [ "$TARGETPLATFORM" = 'linux/amd64' ]; \
	then \
		ln -s /artifacts/linux-x64 build ; \
	elif [ "$TARGETPLATFORM" = 'linux/arm/v7' ]; \
	then \
		ln -s /artifacts/linux-arm build ; \
	elif [ "$TARGETPLATFORM" = 'linux/arm64' ]; \
	then \
		ln -s /artifacts/linux-arm64 build ; \
	else \
		echo "platform $TARGETPLATFORM not supported"; \
		exit 1; \
	fi

FROM mcr.microsoft.com/dotnet/aspnet as final
WORKDIR /app
COPY --from=build /build .

ENTRYPOINT ["dotnet", "Fabiolune.CustomBackend.dll"]